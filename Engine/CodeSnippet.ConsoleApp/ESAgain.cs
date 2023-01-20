using EventStore.ClientAPI;
using EventStore.ClientAPI.SystemData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace CodeSnippet.ConsoleApp
{
    public class ShowEventStoreSampleViaGRPC
    {
        public static void Main()
        {

        }
    }
    //public class ESAgain
    //{
    //    public static IEventStoreConnection _connection;
    //    private static readonly string _username = "admin";
    //    private static readonly string _password = "changeit";
    //    static ESAgain()
    //    {
    //        //ConnectToEventStore();

    //        _connection = EnsurePersistentSubscriptionCreated();
    //    }
    //    public static async Task Main()
    //    {
    //        var eventStream = "NetSuiteRevStream";
    //        var eventtype = "NetSuiteRev";
    //        var eventgroup = "ZoneSwitch";

    //        Console.WriteLine("start with the es 1");
    //        //Publish(new DomainEvent());
    //        Console.WriteLine("end es 2");
    //        WriteToEventStore(eventStream, 
    //            JsonConvert.SerializeObject(new NetSuiteRevEventData
    //            {
    //                Amount = 2,
    //                IsForAccount = true,
    //                BankCode = "025",
    //                BillingWindow = "BillingWindow - data",
    //                DateCreated = DateTime.Now,
    //                IsDeducted = true,
    //                Id = new Random(int.MaxValue).Next(),
    //                IsForCard = true,
    //                ReportGenerated = 3,
    //                SettlementBillingWindow = "try this"

    //            }),
    //            eventtype, 
    //            "{NetSuiteData:Netsuite data}"
    //        );
    //        Console.WriteLine("hmm... done!");
    //    }
    //    public static void Publish(DomainEvent domainEvent)
    //    {
    //        domainEvent = new DomainEvent() { Id = 1 };
    //        _connection.AppendToStreamAsync(
    //            "stream-name",
    //            ExpectedVersion.Any,
    //            new EventData(
    //                Guid.NewGuid(),
    //                domainEvent.GetType().FullName,
    //                false,
    //                Encoding.UTF8.GetBytes(domainEvent.ToString()),
    //                new byte[] { }
    //            )
    //        ).Wait();
    //    }
    //    public static IEventStoreConnection ConnectToEventStore2()
    //    {
    //        var settings = ConnectionSettings.Create().KeepReconnecting().KeepRetrying();
    //        _connection = EventStoreConnection.Create(
    //            settings,
    //            new IPEndPoint(
    //                IPAddress.Parse("10.3.4.12"),
    //                2113
    //            )
    //        );
    //        _connection.Closed += _EventStoreConn_Closed;
    //        _connection.Disconnected += Connection_Disconnected;
    //        _connection.ConnectAsync().Wait();
    //        return _connection;
    //    }

    //    private static void Connection_Disconnected(object sender, ClientConnectionEventArgs e)
    //    {
    //        ConnectToEventStore();
    //    }

    //    private static void _EventStoreConn_Closed(object sender, ClientClosedEventArgs e)
    //    {
    //        if (!string.IsNullOrEmpty(e.Reason)) ConnectToEventStore();
    //    }
    //    private static IEventStoreConnection EnsurePersistentSubscriptionCreated()
    //    {
    //        var conn = ConnectToEventStore();
    //        Console.WriteLine("Connected to EventStore");
    //        //CreateSubscription(conn, "NetSuiteRevStream", "ZoneSwitch");//what for??
    //        return conn;
    //    }
    //    public static IEventStoreConnection ConnectToEventStore()
    //    {
    //        var port = 2113;
    //        var settings = ConnectionSettings.Create()
    //            .KeepReconnecting()
    //            .KeepRetrying();

    //        //_connection = EventStoreConnection.Create(settings, new IPEndPoint(IPAddress.Loopback, port));
    //        _connection = EventStoreConnection.Create(settings, new IPEndPoint(IPAddress.Parse("10.3.4.12"), port));

    //        _connection.Closed += _EventStoreConn_Closed;
    //        _connection.Disconnected += Connection_Disconnected;
    //        // Don’t forget to tell the connection to connect!
    //        _connection.ConnectAsync().GetAwaiter().GetResult();
    //        //_logger.Debug("Event store connected");
    //        //_connection = eventStore;
    //        return _connection;
    //    }
    //    public static void CreateSubscription(IEventStoreConnection conn, string stream, string group)
    //    {
    //        var eventStoreUser = _username;
    //        var eventStorePassword = _password;
    //        PersistentSubscriptionSettings settings = PersistentSubscriptionSettings.Create()
    //            .DoNotResolveLinkTos()
    //            .StartFromCurrent();

    //        try
    //        {
    //            conn.CreatePersistentSubscriptionAsync(stream, group, settings,
    //                new UserCredentials(eventStoreUser, eventStorePassword)).GetAwaiter().GetResult();
    //        }
    //        catch (Exception ex)
    //        {
    //            //if (ex.InnerException.GetType() != typeof(InvalidOperationException)
    //            //    && ex.InnerException?.Message != $"Subscription group {group} on stream {stream} already exists")
    //            //{
    //            //    _logger.Debug(ex.Message);
    //            //}
    //        }
    //    }
    //    private static async Task WriteToStreamRetry(string stream, string data, string eventType, string metaData)
    //    {
    //        try
    //        {
    //            await _connection.AppendToStreamAsync(stream,
    //                    ExpectedVersion.Any,
    //                   GetEventDataFor(data, eventType, metaData));
    //        }
    //        catch (Exception e)
    //        {
    //        }
    //    }
    //    public static async Task WriteToEventStore(string stream, string data, string eventType, string metaData)
    //    {
    //        try
    //        {
    //            await _connection.AppendToStreamAsync(stream,
    //                   ExpectedVersion.Any,
    //                   GetEventDataFor(data, eventType, metaData));
    //        }
    //        catch (Exception e)
    //        {
    //            await WriteToStreamRetry(stream, data, eventType, metaData);
    //        }
    //    }

    //    private static EventData GetEventDataFor(string data, string eventType, string metaData)
    //    {
    //        return new EventData(
    //            Guid.NewGuid(),
    //            eventType,
    //            true,
    //            Encoding.UTF8.GetBytes(data),
    //            Encoding.UTF8.GetBytes(metaData)
    //        );
    //    }

    //}
    //public class DomainEvent
    //{
    //    public int Id { get; set; }
    //}

}
