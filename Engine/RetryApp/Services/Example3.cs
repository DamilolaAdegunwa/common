using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RetryApp.Services
{
	public struct s
	{

	}
	public class Example3
	{
		public class DataService1
		{
			private IWorkerQueue _workerQueue;
		}

		public class DataService
		{
			private static IWorkerQueue s_workerQueue;
			[ThreadStatic]
			private static TimeSpan t_timeSpan;
		}

		public static Action<string> ActionExample1 = x => Console.WriteLine($"x is:\n{x}\n");
		public static Action<string, string> ActionExample2 = (x, y) => Console.WriteLine($"x is:\n{x}, y is {y}\n");
		public static Func<string, int> FuncExample1 = x => Convert.ToInt32(x);
		public static Func<int, int, int> FuncExample2 = (x, y) => x + y;

		public void Method1()
		{
			ActionExample1("string for x");
			ActionExample2("string for x", "string for y");
			Console.WriteLine($"The value is {FuncExample1("1")}\n");
			Console.WriteLine($"The sum is {FuncExample2(1, 2)}\n");
		}

		public delegate void Del(string message);

		public static void DelMethod(string str)
		{
			Console.WriteLine("DelMethod argument: {0}", str);
		}

		static string GetValueFromArray(string[] array, int index)
		{
			try
			{
				return array[index];
			}
			catch (System.IndexOutOfRangeException ex)
			{
				Console.WriteLine("Index is out of range: {0}", index);
				throw;
			}
		}

		public void Method2()
		{
			Console.Write("Enter a dividend: ");
			int dividend = Convert.ToInt32(Console.ReadLine());
			Console.Write("Enter a divisor: ");
			int divisor = Convert.ToInt32(Console.ReadLine());
			if ((divisor != 0) && (dividend / divisor > 0))
			{
				Console.WriteLine("Quotient: {0}", dividend / divisor);
			}
			else
			{
				Console.WriteLine("Attempted division by 0 ends up here.");
			}
		}


		public class Transaction
		{
			public decimal Amount { get; }
			public DateTime Date { get; }
			public string Notes { get; }

			public Transaction(decimal amount, DateTime date, string note)
			{
				Amount = amount;
				Date = date;
				Notes = note;
			}

			public void MakeDeposit(decimal amount, DateTime date, string note)
			{
				List<Transaction> allTransactions = new List<Transaction>();
				if (amount <= 0)
				{
					throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
				}
				var deposit = new Transaction(amount, date, note);
				allTransactions.Add(deposit);
			}

			public void MakeWithdrawal(decimal amount, DateTime date, string note)
			{
				decimal Balance = 0;
				List<Transaction> allTransactions = new List<Transaction>();
				if (amount <= 0)
				{
					throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
				}
				if (Balance - amount < 0)
				{
					throw new InvalidOperationException("Not sufficient funds for this withdrawal");
				}
				var withdrawal = new Transaction(-amount, date, note);
				allTransactions.Add(withdrawal);
			}
		}
		public class BankAccount
		{
			private int accountNumberSeed;

			public BankAccount(string name, decimal initialBalance)
			{
				Number = accountNumberSeed.ToString();
				accountNumberSeed++;
				Owner = name;
				MakeDeposit(initialBalance, DateTime.Now, "Initial balance");
			}

			private void MakeDeposit(decimal initialBalance, DateTime now, string v)
			{
				throw new NotImplementedException();
			}

			public object Number { get; private set; }
			public string Owner { get; }
			public Transaction account { get; private set; }

			public void Testforanegativebalance()
			{
				// Test for a negative balance.
				try
				{
					account.MakeWithdrawal(750, DateTime.Now, "Attempt to overdraw");
				}
				catch (InvalidOperationException e)
				{
					Console.WriteLine("Exception caught trying to overdraw");
					Console.WriteLine(e.ToString());
				}
			}

		}
	}
}
