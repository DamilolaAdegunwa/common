using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
namespace CodeSnippet.ConsoleApp.Services
{
    public class Partitioning
    {
        public void ForEachPartition()
        {
            var partitionCount = System.Environment.ProcessorCount;
            var source = new string[] { "one","two","three","four","five","six" };
            Task.WhenAll(
                from partition in Partitioner.Create(source).GetPartitions(partitionCount)
                select Task.Run(async delegate
                {
                    using (partition)
                    {
                        while (partition.MoveNext())
                        {
                            await Task.Factory.StartNew(()=> Console.WriteLine(partition.Current));
                        }
                    }
                }));
        }
    }
}
