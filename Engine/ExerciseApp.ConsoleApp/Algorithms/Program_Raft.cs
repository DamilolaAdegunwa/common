using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Threading;
namespace ExerciseApp.ConsoleApp.Algorithms
{


public class LogEntry
	{
		public int Term { get; set; }
		public string Command { get; set; }
	}

	public enum RaftState
	{
		Follower,
		Candidate,
		Leader
	}

	public class RaftNode
	{
		public int Id { get; }
		public RaftState State { get; set; }
		public int CurrentTerm { get; set; }
		public int VotedFor { get; set; }
		public List<LogEntry> Log { get; }
		public int CommitIndex { get; set; }
		public int LastApplied { get; set; }
		public int[] NextIndex { get; set; }
		public int[] MatchIndex { get; set; }
		public int VotesReceived { get; set; }

		public RaftNode(int id)
		{
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

		public void StartElection()
		{
			State = RaftState.Candidate;
			CurrentTerm++;
			VotedFor = Id;
			VotesReceived = 1;

			// Send RequestVote RPCs to other nodes
			for (int i = 0; i < Network.Nodes.Length; i++)
			{
				if (i != Id)
				{
					Network.Nodes[i].RequestVote(Id, CurrentTerm, Log.Count - 1);
				}
			}
		}

		public void RequestVote(int candidateId, int term, int lastLogIndex)
		{
			int lastLogTerm = Log[lastLogIndex].Term;

			if (term < CurrentTerm || (term == CurrentTerm && lastLogIndex < Log.Count - 1))
			{
				// Reject the vote request if the candidate's term is older or the log is not up-to-date
				Network.Nodes[candidateId].VoteReceived(Id, false);
			}
			else
			{
				if (VotedFor == -1 || VotedFor == candidateId)
				{
					// Grant the vote if the node has not voted in this term or has voted for the candidate
					VotedFor = candidateId;
					Network.Nodes[candidateId].VoteReceived(Id, true);
				}
				else
				{
					// Reject the vote request if the node has already voted for another candidate in this term
					Network.Nodes[candidateId].VoteReceived(Id, false);
				}
			}
		}

		public void VoteReceived(int voterId, bool voteGranted)
		{
			if (State == RaftState.Candidate && voteGranted && CurrentTerm == Network.Nodes[voterId].CurrentTerm)
			{
				VotesReceived++;
				if (VotesReceived > Network.Nodes.Length / 2)
				{
					BecomeLeader();
				}
			}
			else if (CurrentTerm < Network.Nodes[voterId].CurrentTerm)
			{
				// The node's term is outdated, revert back to follower state
				State = RaftState.Follower;
				CurrentTerm = Network.Nodes[voterId].CurrentTerm;
				VotedFor = -1;
			}
		}

		public void BecomeLeader()
		{
			State = RaftState.Leader;
			NextIndex = new int[Network.Nodes.Length];
			MatchIndex = new int[Network.Nodes.Length];

			for (int i = 0; i < Network.Nodes.Length; i++)
			{
				NextIndex[i] = Log.Count;
				MatchIndex[i] = 0;
			}

			while (State == RaftState.Leader)
			{
				for (int i = 0; i < Network.Nodes.Length; i++)
				{
					if (i != Id)
					{
						if (NextIndex[i] <= Log.Count)
						{
							// Send AppendEntries RPCs to followers
							Network.Nodes[i].AppendEntries(Id, CurrentTerm, NextIndex[i] - 1, Log[NextIndex[i] - 1], CommitIndex);
						}
					}
				}

				// Wait for a certain period before sending AppendEntries RPCs again
				Thread.Sleep(1000);
			}
		}

		public void AppendEntries(int leaderId, int term, int prevLogIndex, LogEntry prevLogEntry, int leaderCommit)
		{
			if (term < CurrentTerm)
			{
				// Reject the AppendEntries request if the leader's term is older
				Network.Nodes[leaderId].AppendEntriesResponse(Id, false);
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
					Network.Nodes[leaderId].AppendEntriesResponse(Id, false);
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

					Network.Nodes[leaderId].AppendEntriesResponse(Id, true);
				}
			}
		}

		public void AppendEntriesResponse(int followerId, bool success)
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
						for (int j = 0; j < Network.Nodes.Length; j++)
						{
							if (j != Id && MatchIndex[j] >= i)
							{
								count++;
							}
						}
						if (count > Network.Nodes.Length / 2)
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
					Network.Nodes[followerId].AppendEntries(Id, CurrentTerm, NextIndex[followerId] - 1, Log[NextIndex[followerId] - 1], CommitIndex);
				}
			}
		}

		public void Start()
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
							StartElection();
						}
						break;
					case RaftState.Candidate:
						Thread.Sleep(1000); // Simulating candidate behavior
						if (State == RaftState.Candidate)
						{
							// Start a new election if the current election fails
							StartElection();
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

	public class Network
	{
		public static RaftNode[] Nodes { get; }

		static Network()
		{
			Nodes = new RaftNode[5];
			for (int i = 0; i < Nodes.Length; i++)
			{
				Nodes[i] = new RaftNode(i);
			}
		}
	}

	public class Program_Raft
	{
		public static void Main_Raft(string[] args)
		{
			Thread[] threads = new Thread[Network.Nodes.Length];
			for (int i = 0; i < Network.Nodes.Length; i++)
			{
				int nodeId = i;
				threads[i] = new Thread(() => Network.Nodes[nodeId].Start());
				threads[i].Start();
			}

			Console.ReadLine();

			for (int i = 0; i < Network.Nodes.Length; i++)
			{
				threads[i].Abort();
			}
		}
	}

}
