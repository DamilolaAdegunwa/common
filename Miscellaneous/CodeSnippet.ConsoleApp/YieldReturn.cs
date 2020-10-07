using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Data;

namespace CodeSnippet.ConsoleApp
{
    public class YieldReturn
    {
        #region 1
        public static IEnumerable<Product> GetAllProducts()
        {
            using (AdventureWorksEntities db = new AdventureWorksEntities())
            {
                var products = from product in db.Product
                               select product;

                foreach (Product product in products)
                {
                    yield return product;
                }
            }
        }

        public class Product
        {
        }

        private class AdventureWorksEntities : IDisposable
        {
            #region IDisposable Support
            private bool disposedValue = false; // To detect redundant calls

            public IEnumerable<Product> Product { get; set; }

            protected virtual void Dispose(bool disposing)
            {
                if (!disposedValue)
                {
                    if (disposing)
                    {
                        // TODO: dispose managed state (managed objects).
                    }

                    // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                    // TODO: set large fields to null.

                    disposedValue = true;
                }
            }

            // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
            // ~AdventureWorksEntities()
            // {
            //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            //   Dispose(false);
            // }

            // This code added to correctly implement the disposable pattern.
            public void Dispose()
            {
                // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
                Dispose(true);
                // TODO: uncomment the following line if the finalizer is overridden above.
                // GC.SuppressFinalize(this);
            }
            #endregion
        }
        #endregion

        #region 2
        //pseudo - code
        //void ConsumeLoop()
        //{
        //    foreach (Consumable item in ProduceList())        // might have to wait here
        //        item.Consume();
        //}

        //IEnumerable<Consumable> ProduceList()
        //{
        //    while (KeepProducing())
        //        yield return ProduceExpensiveConsumable();    // expensive
        //}

        /*
         //pseudo-assembly
        Produce consumable[0]
        Consume consumable[0]                   // immediately yield & Consume
        Produce consumable[1]                   // ConsumeLoop iterates, requesting next item
        Consume consumable[1]                   // consume next
        Produce consumable[2]
        Consume consumable[2]                   // consume next
        Produce consumable[3]
        Consume consumable[3] 
         */
        #endregion

        #region 3
        public static void Main()
        {
            using(IEnumerator<int> iValues =  YieldReturn.Vs().GetEnumerator())
            {
                while(iValues.MoveNext())
                {
                    Console.WriteLine(iValues.Current);
                }
            }
        }
        public static IEnumerable<int> Vs()
        {
            int yield = 500;
            yield return 1;
            yield break;
            yield return 2;
            yield return 3;

        }
        //public IEnumerable<IResult> HandleButtonClick()
        //{
        //    yield return Show.Busy();

        //    var loginCall = new LoginResult(wsClient, Username, Password);
        //    yield return loginCall;
        //    this.IsLoggedIn = loginCall.Success;

        //    yield return Show.NotBusy();
        //}
        ////////
        /*
         public LoginResult : IResult {
            // Constructor to set private members...

            public void Execute(ActionExecutionContext context) {
                wsClient.LoginCompleted += (sender, e) => {
                    this.Success = e.Result;
                    Completed(this, new ResultCompletionEventArgs());
                };
                wsClient.Login(username, password);
            }

            public event EventHandler<ResultCompletionEventArgs> Completed = delegate { };
            public bool Success { get; private set; }
        }
         */
        //public IEnumerable<T> Read<T>(string sql, Func<IDataReader, T> make, params object[] parms)
        //{
        //    using (var connection = CreateConnection())
        //    {
        //        using (var command = CreateCommand(CommandType.Text, sql, connection, parms))
        //        {
        //            command.CommandTimeout = dataBaseSettings.ReadCommandTimeout;
        //            using (var reader = command.ExecuteReader())
        //            {
        //                while (reader.Read())
        //                {
        //                    yield return make(reader);
        //                }
        //            }
        //        }
        //    }
        //}

        #endregion

        #region 4
        public static IEnumerable<Trip> CreatePossibleTrips()
        {
            //IAsyncObservable<T> iao = default;
            for (int i = 0; i < 1000000; i++)
            {
                yield return new Trip
                {
                    Id = i.ToString(),
                    Driver = new Driver { Id = i.ToString() }
                };
            }
        }
        //public async int xyz()
        //{
        //    return default;
        //}
        public class Trip
        {
            public string Id { get; set; }
            public Driver Driver { get; set; }
        }
        public class Driver
        {
            public string Id { get; set; }
        }
        static void Main(string[] args)
        {
            foreach (var trip in CreatePossibleTrips())
            {
                // possible trip is actually calculated only at this point, because of yield
                //if (IsTripGood(trip))
                //{
                //    // match good trip
                //}
                Console.WriteLine($"Trip Id: {trip.Id}, Trip Driver Id: {trip.Driver.Id}");
            }
        }
        #endregion
    }
}
