//using EventStore.ClientAPI;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Text;
//using System.Threading.Tasks;
//namespace CodeSnippet.ConsoleApp
//{
//    public class simple_eventstore_test
//    {
//        public static IEventStoreConnection _connection;
//        static simple_eventstore_test()
//        {
//            ConnectToEventStore();
//        }
//        public static async Task Mainsimple_eventstore_test()
//        {
//            Console.WriteLine("start with the es");
//            Publish(new DomainEvent());
//            Console.WriteLine("end es");
//        }
//        public static void Publish(DomainEvent domainEvent)
//        {
//            domainEvent = new DomainEvent() { Id = 1 };
//            _connection.AppendToStreamAsync(
//                "stream-name",
//                ExpectedVersion.Any,
//                new EventData(
//                    Guid.NewGuid(),
//                    domainEvent.GetType().FullName,
//                    false,
//                    Encoding.UTF8.GetBytes(domainEvent.ToString()),
//                    new byte[] { }
//                )
//            ).Wait();
//        }
//        public static IEventStoreConnection ConnectToEventStore()
//        {
//            var settings = ConnectionSettings.Create().KeepReconnecting().KeepRetrying();
//            _connection = EventStoreConnection.Create(
//                settings,
//                new IPEndPoint(
//                    IPAddress.Parse("10.3.4.12"),
//                    2113
//                )
//            );
//            //_connection.ConnectAsync().Wait();
//            //
//            //var port = 2113;
//            //_connection = EventStoreConnection.Create(settings, new IPEndPoint(IPAddress.Loopback, port));
//            //_connection = EventStoreConnection.Create(settings, new IPEndPoint(167969804, 2113));//10.3.4.12
//            _connection.Closed += _EventStoreConn_Closed;
//            _connection.Disconnected += Connection_Disconnected;
//            //_connection.ConnectAsync().GetAwaiter().GetResult();
//            _connection.ConnectAsync().Wait();
//            return _connection;
//        }

//        private static void Connection_Disconnected(object sender, ClientConnectionEventArgs e)
//        {
//            ConnectToEventStore();
//        }

//        private static void _EventStoreConn_Closed(object sender, ClientClosedEventArgs e)
//        {
//            if (!string.IsNullOrEmpty(e.Reason)) ConnectToEventStore();
//        }
//        public class DomainEvent
//        {
//            public int Id { get; set; }
//        }
//    }
//}
