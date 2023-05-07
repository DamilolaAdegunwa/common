//using EventStore.ClientAPI;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Newtonsoft.Json;
//namespace CodeSnippet.ConsoleApp
//{
//    public class TestES
//    {
//        public static IEventStoreConnection _connection;
//        public static async Task Maines()
//        {
//            var eventStream = "NetSuiteRevStream";
//            var eventtype = "NetSuiteRev";
//            var eventgroup = "ZoneSwitch";
//            //var conn = EventStoreConnection.Create(new Uri("tcp://admin:changeit@localhost:1113"));
//            //var conn = EventStoreConnection.Create(new Uri("wrong!!"));
//            ConnectToEventStore();
//            //await _connection.ConnectAsync();

//            //var data = Encoding.UTF8.GetBytes("{\"a\":\"2\"}");
//            var data = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(
//                            new NetSuiteRevEventData
//                            {
//                                Amount = 2,
//                                IsForAccount = true,
//                                BankCode = "025",
//                                BillingWindow = "BillingWindow - data",
//                                DateCreated = DateTime.Now,
//                                IsDeducted = true,
//                                Id = new Random(int.MaxValue).Next(),
//                                IsForCard = true,
//                                ReportGenerated = 3,
//                                SettlementBillingWindow = "try this"

//                            }));
//            //var metadata = Encoding.UTF8.GetBytes("{}");
//            var metadata = Encoding.UTF8.GetBytes("{NetSuiteData:Netsuite data}");

//            var evt = new EventData(Guid.NewGuid(), eventtype, true, data, metadata);

//            await _connection.AppendToStreamAsync(eventStream, ExpectedVersion.Any, evt);

//            var streamEvents = await _connection.ReadStreamEventsForwardAsync(eventtype, 0, 1, false);
//            var returnedEvent = streamEvents.Events[0].Event;

//            Console.WriteLine(
//                "Read event with data: {0}, metadata: {1}",
//                Encoding.UTF8.GetString(returnedEvent.Data),
//                Encoding.UTF8.GetString(returnedEvent.Metadata)
//            );
//        }

//        public static IEventStoreConnection ConnectToEventStore()
//        {
//            //var port = 2113;
//            var settings = ConnectionSettings.Create().KeepReconnecting().KeepRetrying();
//            //_connection = EventStoreConnection.Create(settings, new IPEndPoint(IPAddress.Loopback, port));
//            //_connection = EventStoreConnection.Create(settings, new IPEndPoint(167969804, 2113));//10.3.4.12

//            //_connection = EventStoreConnection.Create(new Uri("tcp://admin:changeit@localhost:1113"));
//            _connection = EventStoreConnection.Create(new Uri("tcp://admin:changeit@10.3.4.12:2113"));
//            _connection.Closed += _EventStoreConn_Closed;
//            _connection.Disconnected += Connection_Disconnected;
//            _connection.ConnectAsync().GetAwaiter().GetResult();
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
//    }
//    public class NetSuiteRevEventData
//    {
//        public int Id { get; set; }
//        public decimal Amount { get; set; }
//        public DateTime DateCreated { get; set; }
//        public bool IsForAccount { get; set; }
//        public bool IsForCard { get; set; }
//        public bool IsDeducted { get; set; }
//        public int ReportGenerated { get; set; }
//        public string BankCode { get; set; }
//        public string BillingWindow { get; set; }
//        public string SettlementBillingWindow { get; set; }
//    }
//    public class EventStoreMetadata
//    {
//        public string NetSuiteData { get; set; }
//    }
//    public class EventStoreInternalData
//    {
//        public string EventId { get; set; }
//    }
//}
