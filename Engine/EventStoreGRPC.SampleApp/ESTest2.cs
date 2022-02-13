using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EventStore.ClientAPI;
using EventStore.ClientAPI.Projections;
using EventStore.ClientAPI.SystemData;
namespace EventStoreGRPC.SampleApp
{
    public class ESTest2
    {
        public static IEventStoreConnection storeConnection;
        public static async Task Main()
        {
            storeConnection = ConnectToES();
            storeConnection.Closed += _EventStoreConn_Closed;
            storeConnection.Disconnected += Connection_Disconnected;



            const string streamName = "newstream";
            const string eventType = "event-type";
            const string data = "{ \"a\":\"2\"}";
            const string metadata = "{}";


            var eventPayload = new EventData(
            eventId: Guid.NewGuid(),
            type: eventType,
            isJson: true,
            data: Encoding.UTF8.GetBytes(data),
            metadata: Encoding.UTF8.GetBytes(metadata)
            );

            var result = await storeConnection.AppendToStreamAsync(streamName, ExpectedVersion.Any, eventPayload);


            var readEvents = await storeConnection.ReadStreamEventsForwardAsync(streamName, 0, 10, true);


            foreach (var evt in readEvents.Events)
            {
                Console.WriteLine(Encoding.UTF8.GetString(evt.Event.Data));
            }
        }
        public static IEventStoreConnection ConnectToES()
        {
            var connection = EventStoreConnection.Create(
            new Uri("tcp://admin:changeit@localhost:2113")
            );
            connection.ConnectAsync().Wait();
            return connection;
        }
        private static void Connection_Disconnected(object sender, ClientConnectionEventArgs e)
        {
            storeConnection = ConnectToES();
        }

        private static void _EventStoreConn_Closed(object sender, ClientClosedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Reason))
            {
                storeConnection = ConnectToES();
            }
        }
    }
}
//EventStore.ClientAPI.Exceptions.ConnectionClosedException: 'Connection 'ES-e67c9f7e-091b-4786-8401-e435da27d41c' was closed.'