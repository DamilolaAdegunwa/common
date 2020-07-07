using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CodeSnippet.ConsoleApp.Services
{
    public class MyQueue<T>
    {
        public readonly ConcurrentQueue<T> _queue = new ConcurrentQueue<T>();
        public readonly SemaphoreSlim _sem = new SemaphoreSlim(0);

        public void Write(T item)
        {
            _queue.Enqueue(item);
            _sem.Release();
        }

        public async Task<T> ReadAsync()
        {
            await _sem.WaitAsync();
            _queue.TryDequeue(out T item);

            return item;
        }
    }
}
