using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseApp.ConsoleApp.Algorithms
{

public class PaxosNode
	{
		private int nodeId;
		private int numNodes;
		private int proposerId;
		private int acceptorId;
		private int learnerId;
		private Dictionary<int, Proposal> proposals;

		public PaxosNode(int id, int numNodes)
		{
			nodeId = id;
			this.numNodes = numNodes;
			proposerId = 0;
			acceptorId = 0;
			learnerId = 0;
			proposals = new Dictionary<int, Proposal>();
		}

		public void Start()
		{
			while (true)
			{
				// Phase 1: Prepare Phase
				int proposalNumber = GenerateProposalNumber();
				Prepare(proposalNumber);

				// Phase 2: Accept Phase
				Proposal maxAcceptedProposal = Accept(proposalNumber);

				// Phase 3: Learn Phase
				Learn(maxAcceptedProposal);
			}
		}

		private int GenerateProposalNumber()
		{
			// In a real implementation, a unique proposal number would be generated
			// based on the node's ID, timestamp, or other suitable mechanism.
			// For simplicity, we use a counter here.
			return proposals.Count + 1;
		}

		private void Prepare(int proposalNumber)
		{
			// Send prepare message to all acceptors
			for (int i = 1; i <= numNodes; i++)
			{
				if (i != nodeId)
				{
					// Simulating message exchange
					int promise = AcceptorPromise(i, proposalNumber);
					if (promise != -1)
					{
						// Phase 1b: Received promise from acceptor
						if (!proposals.ContainsKey(proposalNumber))
						{
							proposals.Add(proposalNumber, new Proposal(proposalNumber));
						}
						proposals[proposalNumber].AddPromise(promise);
					}
				}
			}
		}

		private Proposal Accept(int proposalNumber)
		{
			int acceptCount = 0;
			Proposal maxAcceptedProposal = null;

			// Check if the majority of promises is received
			if (proposals.ContainsKey(proposalNumber) && proposals[proposalNumber].HasMajority(numNodes))
			{
				// Create accept message and send it to all acceptors
				for (int i = 1; i <= numNodes; i++)
				{
					if (i != nodeId)
					{
						// Simulating message exchange
						int accepted = AcceptorAccept(i, proposals[proposalNumber]);
						if (accepted != -1)
						{
							// Phase 2b: Received accept from acceptor
							acceptCount++;

							if (maxAcceptedProposal == null || accepted > maxAcceptedProposal.ProposalNumber)
							{
								maxAcceptedProposal = new Proposal(accepted, proposals[proposalNumber].Value);
							}
						}
					}
				}
			}

			// Check if the majority of accepts is received
			if (acceptCount >= numNodes / 2)
			{
				return maxAcceptedProposal;
			}

			return null;
		}

		private void Learn(Proposal maxAcceptedProposal)
		{
			if (maxAcceptedProposal != null)
			{
				// Send learn message to all learners
				for (int i = 1; i <= numNodes; i++)
				{
					if (i != nodeId)
					{
						// Simulating message exchange
						LearnerLearn(i, maxAcceptedProposal);
					}
				}

				// Phase 3b: Learn the accepted value
				Console.WriteLine($"Node {nodeId} learned value: {maxAcceptedProposal.Value}");
			}
		}

		// Simulated message exchanges between nodes

		private int AcceptorPromise(int acceptorId, int proposalNumber)
		{
			// Simulating message exchange
			// Acceptor responds with a promise if the proposal number is greater than any seen before
			// In a real implementation, network communication and logic would be involved.
			if (acceptorId == this.acceptorId && proposalNumber > this.proposerId)
			{
				this.proposerId = proposalNumber;
				return proposalNumber;
			}
			return -1;
		}

		private int AcceptorAccept(int acceptorId, Proposal proposal)
		{
			// Simulating message exchange
			// Acceptor responds with an accept if the proposal number is the highest seen and the value is accepted
			// In a real implementation, network communication and logic would be involved.
			if (acceptorId == this.acceptorId && proposal.ProposalNumber == this.proposerId)
			{
				return proposal.ProposalNumber;
			}
			return -1;
		}

		private void LearnerLearn(int learnerId, Proposal proposal)
		{
			// Simulating message exchange
			// Learner receives the accepted proposal and learns the value
			// In a real implementation, network communication and logic would be involved.
			if (learnerId == this.learnerId)
			{
				Console.WriteLine($"Node {nodeId} received learn message: {proposal.Value}");
			}
		}
	}

	public class Proposal
	{
		public int ProposalNumber { get; }
		public string Value { get; }
		private HashSet<int> promises;

		public Proposal(int proposalNumber, string value = null)
		{
			ProposalNumber = proposalNumber;
			Value = value;
			promises = new HashSet<int>();
		}

		public void AddPromise(int promise)
		{
			promises.Add(promise);
		}

		public bool HasMajority(int numNodes)
		{
			return promises.Count >= numNodes / 2;
		}
	}

	public class Program_Paxos
	{
		public static void Main_Paxos(string[] args)
		{
			int numNodes = 5;
			PaxosNode[] nodes = new PaxosNode[numNodes];

			for (int i = 0; i < numNodes; i++)
			{
				nodes[i] = new PaxosNode(i + 1, numNodes);
			}

			for (int i = 0; i < numNodes; i++)
			{
				int nodeId = i;
				System.Threading.Thread thread = new System.Threading.Thread(() => nodes[nodeId].Start());
				thread.Start();
			}

			Console.ReadLine();
		}
	}

}
