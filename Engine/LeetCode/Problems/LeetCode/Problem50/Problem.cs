using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Problems.LeetCode.Problem50
{
	public class Solution
	{
		public double MyPow(double x, int n)
		{
			return Math.Pow(x, n);
		}
		public double MyPowOld(double x, int n)
		{
			long nx = n;
			if (nx == 0)
			{
				return 1;
			}
			
			if (nx < 0)
			{
				x = 1 / x;
				nx = -nx;
			}

			double result = 1;
			double currentProduct = x;

			while (nx != 1)
			{
				if (nx % 2 == 1)
				{
					result *= currentProduct;
				}

				currentProduct *= currentProduct;
				nx /= 2;
			}

			return result;
		}
	}
}