using Newtonsoft.Json;
using System.ComponentModel;
using System.Data;
namespace RaftConsoleApp
{
	//internal class Program
	//{
	//	static void Main(string[] args)
	//	{
	//		Console.WriteLine("Hello, World!");
	//	}
	//}

	public class LogEntry
	{
		public int Term { get; set; }
		public string Command { get; set; }

		public static List<LogEntry> logEntries = new List<LogEntry>() { 
			new LogEntry() { Term = 0, Command = "Create-Customer"},
			new LogEntry() { Term = 0, Command = "Customer-Login"},
			new LogEntry() { Term = 0, Command = "Edit-Customer-Profile"},
			new LogEntry() { Term = 0, Command = "Customer-Order"},
			new LogEntry() { Term = 0, Command = "Customer-Invoice"},
			new LogEntry() { Term = 0, Command = "Customer-Payment"},
			new LogEntry() { Term = 0, Command = "Customer-Receipt"},
			new LogEntry() { Term = 0, Command = "View-Customer-History"},
		};

		public static string[] Commands = 
			{ "Create-Customer", "Customer-Login","Edit-Customer-Profile","Customer-Order", "Customer-Invoice","Customer-Payment","Customer-Receipt" ,"View-Customer-History" };
	}

	public enum RaftState
	{
		None,
		Follower,
		Candidate,
		Leader
	}

	public interface IRaftNode
	{

	}

	public class RaftNode : INotifyPropertyChanged, IRaftNode
	{
		public int Id { get; }
		public RaftState _state { get; set; }
		public RaftState State { get { return _state; } set {
				_state = value; OnPropertyChanged(nameof(State));
			} }
		public int CurrentTerm { get; set; }
		public int VotedFor { get; set; }
		private List<LogEntry> _log;
		public List<LogEntry> Log {
			get { return _log; }
			set {
				_log = value;
				OnPropertyChanged(nameof(Log));
			} }
		public int CommitIndex { get; set; }
		public int LastApplied { get; set; }
		public int[] NextIndex { get; set; }
		public int[] MatchIndex { get; set; }
		public int VotesReceived { get; set; }
		public int Timeout { get; set; }//150 - 300

		//constructor
		public RaftNode()
		{
			PropertyChanged += Program.RaftNode_PropertyChanged;
		}
		//static RaftNode()
		//{
		//	new RaftNode().PropertyChanged += RaftNode_PropertyChanged;
		//}
		public RaftNode(int id)
		{
			PropertyChanged += Program.RaftNode_PropertyChanged;
			Id = id;
			State = RaftState.Follower;
			CurrentTerm = 0;
			VotedFor = -1;
			Log = new List<LogEntry>();
			CommitIndex = 0;
			LastApplied = 0;
			NextIndex = new int[0];
			MatchIndex = new int[0];
			VotesReceived = 0;
		}

		//events (raiser, property and handler)
		protected virtual void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		public event PropertyChangedEventHandler? PropertyChanged;

		//methods
		public void StartElection(RaftCluster network)
		{
			State = RaftState.Candidate;
			CurrentTerm++;
			VotedFor = Id;
			VotesReceived = 1;

			// Send RequestVote RPCs to other nodes
			for (int i = 0; i < network.Nodes.Length; i++)
			{
				if (i != Id)
				{
					network.Nodes[i].RequestVote(Id, CurrentTerm, Log.Count - 1, network);
				}
			}
		}

		public void RequestVote(int candidateId, int term, int lastLogIndex, RaftCluster network)
		{
			int lastLogTerm = Log.Count > 0 ? Log[lastLogIndex].Term : 0;

			if (term < CurrentTerm || (term == CurrentTerm && lastLogIndex < Log.Count - 1))
			{
				// Reject the vote request if the candidate's term is older or the log is not up-to-date
				network.Nodes[candidateId].VoteReceived(Id, false, network);
			}
			else
			{
				if (VotedFor == -1 || VotedFor == candidateId)
				{
					// Grant the vote if the node has not voted in this term or has voted for the candidate
					VotedFor = candidateId;
					network.Nodes[candidateId].VoteReceived(Id, true, network);
				}
				else
				{
					// Reject the vote request if the node has already voted for another candidate in this term
					network.Nodes[candidateId].VoteReceived(Id, false, network);
				}
			}
		}

		public void VoteReceived(int voterId, bool voteGranted, RaftCluster network)
		{
			if (State == RaftState.Candidate && voteGranted && CurrentTerm == network.Nodes[voterId].CurrentTerm)
			{
				VotesReceived++;
				if (VotesReceived > network.Nodes.Length / 2)
				{
					BecomeLeader(network);
				}
			}
			else if (CurrentTerm < network.Nodes[voterId].CurrentTerm)
			{
				// The node's term is outdated, revert back to follower state
				State = RaftState.Follower;
				CurrentTerm = network.Nodes[voterId].CurrentTerm;
				VotedFor = -1;
			}
		}

		public void BecomeLeader(RaftCluster network)
		{
			State = RaftState.Leader;
			NextIndex = new int[network.Nodes.Length];
			MatchIndex = new int[network.Nodes.Length];

			for (int i = 0; i < network.Nodes.Length; i++)
			{
				NextIndex[i] = Log.Count;
				MatchIndex[i] = 0;
			}

			while (State == RaftState.Leader)
			{
				for (int i = 0; i < network.Nodes.Length; i++)
				{
					if (i != Id)
					{
						if (NextIndex[i] <= Log.Count)
						{
							// Send AppendEntries RPCs to followers
							network.Nodes[i].AppendEntries(Id, CurrentTerm, NextIndex[i] - 1, Log[NextIndex[i] - 1], CommitIndex, network);
						}
					}
				}

				// Wait for a certain period before sending AppendEntries RPCs again
				Thread.Sleep(1000);
			}
		}

		public void AppendEntries(int leaderId, int term, int prevLogIndex, LogEntry prevLogEntry, int leaderCommit, RaftCluster network)
		{
			if (term < CurrentTerm)
			{
				// Reject the AppendEntries request if the leader's term is older
				network.Nodes[leaderId].AppendEntriesResponse(Id, false, network);
			}
			else
			{
				if (term > CurrentTerm)
				{
					// Update the node's term and revert back to follower state
					State = RaftState.Follower;
					CurrentTerm = term;
					VotedFor = -1;
				}

				if (prevLogIndex >= Log.Count || Log[prevLogIndex].Term != prevLogEntry.Term)
				{
					// Reject the AppendEntries request if the previous log entry does not match
					network.Nodes[leaderId].AppendEntriesResponse(Id, false, network);
				}
				else
				{
					// Append new entries to the log
					Log.RemoveRange(prevLogIndex + 1, Log.Count - prevLogIndex - 1);
					Log.Add(prevLogEntry);

					if (leaderCommit > CommitIndex)
					{
						// Update the commit index if necessary
						CommitIndex = Math.Min(leaderCommit, Log.Count - 1);
					}

					network.Nodes[leaderId].AppendEntriesResponse(Id, true, network);
				}
			}
		}

		public void AppendEntriesResponse(int followerId, bool success, RaftCluster network)
		{
			if (State == RaftState.Leader)
			{
				if (success)
				{
					NextIndex[followerId] = Log.Count;
					MatchIndex[followerId] = Log.Count - 1;

					// Update the commit index if a majority has replicated the log entry
					for (int i = Log.Count - 1; i > CommitIndex; i--)
					{
						int count = 1;
						for (int j = 0; j < network.Nodes.Length; j++)
						{
							if (j != Id && MatchIndex[j] >= i)
							{
								count++;
							}
						}
						if (count > network.Nodes.Length / 2)
						{
							CommitIndex = i;
							break;
						}
					}
				}
				else
				{
					// Decrement the next index and retry AppendEntries RPC
					NextIndex[followerId]--;
					network.Nodes[followerId].AppendEntries(Id, CurrentTerm, NextIndex[followerId] - 1, Log[NextIndex[followerId] - 1], CommitIndex, network);
				}
			}
		}

		public Task Start(RaftCluster network)
		{
			while (true)
			{
				switch (State)
				{
					case RaftState.Follower:
						Thread.Sleep(1000); // Simulating follower behavior
						if (State == RaftState.Follower)
						{
							// Start an election if no leader heartbeats received within a certain time
							StartElection(network);
						}
						break;
					case RaftState.Candidate:
						Thread.Sleep(1000); // Simulating candidate behavior
						if (State == RaftState.Candidate)
						{
							// Start a new election if the current election fails
							StartElection(network);
						}
						break;
					case RaftState.Leader:
						// Perform leader activities
						Thread.Sleep(1000); // Simulating leader behavior
						break;
				}
			}
		}


	}

	public class RaftClusterMetadata
	{

	}

	public interface INetwork
	{

	}
	//public class Network : INetwork
	public class RaftCluster : INetwork
	{
		public RaftClusterMetadata Metadata { get; set; }
		public string Id;
		public RaftNode[] Nodes { get; }

		public RaftCluster()
		{
			Id = Guid.NewGuid().ToString();
			Nodes = new RaftNode[5];
			for (int i = 0; i < Nodes.Length; i++)
			{
				Nodes[i] = new RaftNode(i);
			}
		}

		public async Task<bool> LeaderDetection()
		{
			return Nodes.Any(n => n.State == RaftState.Leader);
		}

		//public Task UpdateLeader()
		//{
		//	//this is to simulate external data coming to the leader
		//	while (true)
		//	{
		//		if (State == RaftState.Leader)
		//		{
		//			var newEntry = new LogEntry
		//			{
		//				Term = CurrentTerm,
		//				Command = Guid.NewGuid().ToString(),
		//			};
		//			Log.Add(newEntry);
		//			//update other nodes

		//		}
		//	}
		//}
		public Task AppendLogToLeader(RaftCluster network, string command = null)
		{
			//this is to simulate external data coming to the leader
			while (true)
			{
				var leader = Nodes.Where(n => n.State == RaftState.Leader).FirstOrDefault();
				if (leader == null)
				{
					continue;
				}
				if (leader.State == RaftState.Leader)
				{
					var newEntry = new LogEntry
					{
						Term = leader.CurrentTerm,
						Command = command ?? Guid.NewGuid().ToString(),
					};
					leader.Log.Add(newEntry);
					//update other nodes
					var others = Nodes.Where(n => n.State != RaftState.Leader).ToList();
					foreach ( var node in others )
					{
						node.AppendEntries(leader.Id, leader.CurrentTerm, leader.Log.Count - 1, leader.Log[leader.Log.Count - 1], leader.CommitIndex, network);
					}
				}
			}
		}

	}

	public class Program
	{
		//public static void Main(string[] args)
		//{
		//	Thread[] threads = new Thread[Network.Nodes.Length];
		//	for (int i = 0; i < Network.Nodes.Length; i++)
		//	{
		//		int nodeId = i;
		//		threads[i] = new Thread(() => Network.Nodes[nodeId].Start());
		//		threads[i].Start();
		//	}

		//	Console.ReadKey();

		//	//for (int i = 0; i < Network.Nodes.Length; i++)
		//	//{
		//	//	//threads[i].Abort();
		//	//	//threads[i].Interrupt();
		//	//}
		//}
		public static RaftCluster _network;
		public static void Main(string[] args)
		{
			_network = new RaftCluster();
			//start the network and nodes
			for (int i = 0; i < _network.Nodes.Length; i++)
			{
				int nodeId = i;
				//Task.Run(() => Network.Nodes[nodeId].Start());
				Task.Run(() => {
					var node = _network.Nodes[nodeId];
					node.Log = LogEntry.logEntries;
					node.Start(_network);
				});
				
			}

			//show the state of the network
			//Console.ReadKey();
			Task.Run(() => {
				while (true)
				{
					Console.WriteLine(JsonConvert.SerializeObject(_network.Nodes, Formatting.Indented));
					Console.WriteLine("\n\n\n");
					Thread.Sleep(4000);
				}
			});
			
		}
		public static void RaftNode_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			RaftNode node = null;
			if(sender is not null && sender is RaftNode)
			{
				node = sender as RaftNode;
			}
			else
			{
				throw new Exception("sender is not a RaftNode");
			}
			if (e.PropertyName == nameof(RaftNode.Log))
			{
				//code goes here
				Console.WriteLine("the 'RaftNode.Log' was set");
			}
			if (e.PropertyName == nameof(RaftNode.State))
			{
				//code goes here
				Console.WriteLine("the 'RaftNode.State' was set");
				bool isThereALeader = _network?.Nodes?.Any(n => n.State == RaftState.Leader)??false;
				if(node.State == RaftState.Candidate && isThereALeader)
				{
					node.State = RaftState.Follower;
				}

			} 
		}
	}

}
/*
 In this implementation, we have a simplified version of the Raft algorithm. The LogEntry class represents a log entry with a term and a command. The RaftNode class represents a node in the Raft cluster and contains the essential properties and methods for the algorithm.

The StartElection method is called when a node wants to start a new election. It transitions the node to the candidate state, increments the current term, votes for itself, and sends RequestVote RPCs to other nodes.

The RequestVote method is called when a node receives a RequestVote RPC. It grants or rejects the vote based on the candidate's term and log up-to-dateness.

The VoteReceived method is called when a node receives a vote response from another node. It counts the votes received and transitions to the leader state if it receives a majority of votes. If the node's term is outdated, it reverts back to the follower state.

The BecomeLeader method is called when a node becomes the leader. It sets the state to leader, initializes the next and match index arrays, and starts sending AppendEntries RPCs to followers.

The AppendEntries method is called when a node receives an AppendEntries RPC. It checks the term and previous log entry to determine if the request is valid. If so, it appends new entries to its log and updates the commit index if necessary.

The AppendEntriesResponse method is called when a node receives a response to its AppendEntries RPC. It updates the next and match index arrays based on the success of the request. It also checks if the commit index needs to be updated based on majority replication.

The Start method is the main loop of a node. It simulates the behavior of a follower, candidate, or leader depending on the current state.

In the Network class, we create a simple network of 5 nodes for demonstration purposes.

In the Main method, we start each node in a separate thread and allow user input to terminate the program.
 */
/*
please include implementation for the following:

- add method to get all leaders
- add method to get all followers
- set all RaftNode to candidate when there is no leader
- enforce "single leader" rule
- discover when there is no leader.
- make the leader send heartbeat message at an interval specified from a property named "ElectionTimeout", is an "int" and which is a number randomly set between 150 - 300
- add relevant properties to the "RaftClusterMetadata" class
- include in the metadata a property that saves the node that started the current term
- the currentTerm property on the metadata can only be incremented if there is no leader
- include implementation for split detection and resolution
- enforce rule "Election safety: at most one leader can be elected in a given term."
- enforce rule "Leader append-only: a leader can only append new entries to its logs (it can neither overwrite nor delete entries)."
- enforce rule "Log matching: if two logs contain an entry with the same index and term, then the logs are identical in all entries up through the given index."
- enforce rule "Leader completeness: if a log entry is committed in a given term then it will be present in the logs of the leaders since this term."
- enforce rule "State machine safety: if a server has applied a particular log entry to its state machine, then no other server may apply a different command for the same log."

FOR EACH OF THE IMPLEMENTATION THAT YOU DO, PUT A COMMENT ON TOP OF THE IMPLEMENTATION (E.G. FOR THE FIRST ONE, YOU WILL PUT "//add method to get all leaders" ON TOP OF THE IMPLEMENTATION SO I WILL BE ABLE TO TRACK FOR EACH OF THE ADDITION.
*/