using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Problems.Others
{
	//internal class Percolation
	//{
	//}
	//using System;

	public class Percolation
	{
		private int[][] grid; // Grid to represent the percolation system
		private int size; // Size of the grid
		private int openSites; // Count of open sites
		private WeightedQuickUnionUF uf; // Union-Find data structure to track connections
		private int virtualTop; // Virtual top site
		private int virtualBottom; // Virtual bottom site

		// Constructor to initialize the percolation system
		public Percolation(int n)
		{
			if (n <= 0)
			{
				throw new ArgumentException("Grid size must be greater than 0");
			}

			size = n;
			grid = new int[n][];
			for (int i = 0; i < n; i++)
			{
				grid[i] = new int[n];
			}
			openSites = 0;

			// Create a new Union-Find data structure with virtual top and bottom sites
			uf = new WeightedQuickUnionUF(n * n + 2);
			virtualTop = 0;
			virtualBottom = n * n + 1;
		}

		// Open a site in the grid
		public void Open(int row, int col)
		{
			ValidateIndices(row, col);

			if (!IsOpen(row, col))
			{
				grid[row - 1][col - 1] = 1;
				openSites++;

				// Connect the site to its neighboring open sites
				int siteIndex = GetSiteIndex(row, col);
				if (row == 1)
				{
					uf.Union(virtualTop, siteIndex);
				}
				if (row == size)
				{
					uf.Union(virtualBottom, siteIndex);
				}

				// Check top site
				if (row > 1 && IsOpen(row - 1, col))
				{
					int topSiteIndex = GetSiteIndex(row - 1, col);
					uf.Union(siteIndex, topSiteIndex);
				}

				// Check bottom site
				if (row < size && IsOpen(row + 1, col))
				{
					int bottomSiteIndex = GetSiteIndex(row + 1, col);
					uf.Union(siteIndex, bottomSiteIndex);
				}

				// Check left site
				if (col > 1 && IsOpen(row, col - 1))
				{
					int leftSiteIndex = GetSiteIndex(row, col - 1);
					uf.Union(siteIndex, leftSiteIndex);
				}

				// Check right site
				if (col < size && IsOpen(row, col + 1))
				{
					int rightSiteIndex = GetSiteIndex(row, col + 1);
					uf.Union(siteIndex, rightSiteIndex);
				}
			}
		}

		// Check if a site is open
		public bool IsOpen(int row, int col)
		{
			ValidateIndices(row, col);
			return grid[row - 1][col - 1] == 1;
		}

		// Check if a site is full
		public bool IsFull(int row, int col)
		{
			ValidateIndices(row, col);
			int siteIndex = GetSiteIndex(row, col);
			return uf.Connected(virtualTop, siteIndex);
		}

		// Get the number of open sites
		public int NumberOfOpenSites()
		{
			return openSites;
		}

		// Check if the system percolates
		public bool Percolates()
		{
			return uf.Connected(virtualTop, virtualBottom);
		}

		// Validate row and column indices
		private void ValidateIndices(int row, int col)
		{
			if (row < 1 || row > size || col < 1 || col > size)
			{
				throw new ArgumentException("Row or column index is out of range");
			}
		}

		// Get the index of a site in the Union-Find data structure
		private int GetSiteIndex(int row, int col)
		{
			return (row - 1) * size + col;
		}

		// Main method for testing the Percolation class
		public static void Main_Percolation(string[] args)
		{
			int gridSize = 5;
			Percolation percolation = new Percolation(gridSize);

			// Open some sites
			percolation.Open(1, 1);
			percolation.Open(2, 1);
			percolation.Open(2, 2);
			percolation.Open(3, 2);
			percolation.Open(4, 2);
			percolation.Open(4, 3);
			percolation.Open(5, 3);
			percolation.Open(5, 4);
			percolation.Open(5, 5);

			// Check if specific sites are open and full
			Console.WriteLine("Is site (3, 2) open? " + percolation.IsOpen(3, 2));
			Console.WriteLine("Is site (4, 3) full? " + percolation.IsFull(4, 3));

			// Check number of open sites
			Console.WriteLine("Number of open sites: " + percolation.NumberOfOpenSites());

			// Check if the system percolates
			Console.WriteLine("Does the system percolate? " + percolation.Percolates());
		}
	}
	//using System;

	public class WeightedQuickUnionUF
	{
		private int[] parent;
		private int[] size;

		public WeightedQuickUnionUF(int n)
		{
			parent = new int[n];
			size = new int[n];
			for (int i = 0; i < n; i++)
			{
				parent[i] = i;
				size[i] = 1;
			}
		}

		private int Root(int i)
		{
			while (i != parent[i])
			{
				parent[i] = parent[parent[i]];
				i = parent[i];
			}
			return i;
		}

		public bool Connected(int p, int q)
		{
			return Root(p) == Root(q);
		}

		public void Union(int p, int q)
		{
			int rootP = Root(p);
			int rootQ = Root(q);
			if (rootP == rootQ)
			{
				return;
			}
			if (size[rootP] < size[rootQ])
			{
				parent[rootP] = rootQ;
				size[rootQ] += size[rootP];
			}
			else
			{
				parent[rootQ] = rootP;
				size[rootP] += size[rootQ];
			}
		}
	}

}
