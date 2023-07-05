using Polly;
using Polly.Retry;
using RetryApp.Services;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Windows.Markup;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
namespace RetryApp
{
	//public class Program
	//{
	//	int[] arrFront = { 5, 4, 3, 2, 1 };
	//	int[] arrBack = { 6, 7, 8, 9, 10 };

	//	// create new Deque using these arrays

	//	Deque<int> d = new Deque<int>(arrBack, arrFront);
	//	public static string Name = "Damiilola Adegunwa";
	//	public string NickName = "Damiilola Adegunwa";
	//	public required string Status;
	//	[field: NonSerialized]
	//	public int Id { get; set; }
	//	[SetsRequiredMembers]
	//	public Program() {
	//		Status = string.Empty;
	//	}
	//	public static async Task Main()
	//	{
	//		//var x = Name;
	//		//var y = new Program().NickName;
	//		//Program_Animal.Main_Animal();
	//		//await Example.Main_Example();
	//		//var ts = Task.Run(() => { return "Hello"; });
	//		//var s = await ts;
	//		//Console.WriteLine($"the 's' value is: {s}");
	//		//ExampleAwaitClass.Main_Example();
	//		//ThreadStaticClass.Main_ThreadStaticClass();
	//		//Program_AutoResetEvent.Main_AutoResetEvent();
	//	}
	//	public void Method()
	//	{
	//		var x = Program.Name;
	//		var y = NickName;
	//	}
	//}
}