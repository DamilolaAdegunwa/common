using EventStore.Client;
using System;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace EventStoreGRPC.SampleApp
{
    public class Program
    {
        private static CancellationToken cancellationToken;

        public static async Task Main(string[] args)
        {
            var settings = EventStoreClientSettings.Create("esdb://admin:changeit@10.3.4.12:1113");
            var client = new EventStoreClient(settings);

            var evt = new TestEvent
            {
                EntityId = Guid.NewGuid().ToString("N"),
                ImportantData = "I wrote my first event!"
            };

            var eventData = new EventData(
                Uuid.NewUuid(),
                "TestEvent",
                JsonSerializer.SerializeToUtf8Bytes(evt)
            );

            await client.AppendToStreamAsync(
                "some-stream",
                StreamState.Any,
                new[] { eventData },
                cancellationToken: cancellationToken
            );
            var result = client.ReadStreamAsync(
                Direction.Forwards,
                "some-stream",
                StreamPosition.Start,
                cancellationToken: cancellationToken);

            var events = await result.ToListAsync(cancellationToken);
            Console.WriteLine("Hello World!");
        }

        private class TestEvent
        {
            public string EntityId { get; set; }
            public string ImportantData { get; set; }
        }
    }
}
