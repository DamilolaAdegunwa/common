using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading;
using System.Linq;
using System.Reactive.Concurrency;
using System.Windows;
//using System.Windows.Media.Imaging;
namespace CodeSnippet.ConsoleApp
{
    public class PracticalRx
    {
        public ObservableCollection<BitmapImage> ImagesToDisplay
        {
            get;
            protected set;
        }
        public static void MainPracticalRx()
        {
            //public string Translate(TranslateRequest request);
            //public IAsyncResult BeginTranslate(TranslateRequest request, AsyncCallback callback, objectcontext);
            //public string EndTranslate(IAsyncResult asyncResult);
            //IObservable<string> TranslateToSpanishAsync(this LanguageServiceClient client, string englishText);
            new PracticalRx().AddTwoNumbersAsync(5, 4)
            .Subscribe(x => Console.WriteLine(x));//use this!!
            Console.WriteLine("Done!!");
            Console.ReadKey();
        }
        IObservable<int> AddTwoNumbersAsync(int a, int b)
        {
            //return Observable.Start(() => AddTwoNumbers(a, b));
            return Observable.Return(AddTwoNumbers(a, b));
        }
        int AddTwoNumbers(int a, int b)
        {
            return a + b;
        }
        IObservable<int> MultiplyByFiveObservable(int x)
        {
            return Observable.Return(MultiplyByFive(x));
        }
        int MultiplyByFive(int x)
        {
            return x * 5;
        }

        public class BitmapImage
        {
        }
    }
    public static class TranslateToSpanishAsyncExtension
    {
        static IObservable<string> TranslateToSpanishAsync(this LanguageServiceClient client, string englishText)
        {
            var subject = new AsyncSubject<string>();
            const string appId = "YourAppIdHere";
            client.BeginTranslate(
            new TranslateRequest(appId, englishText, "en", "es"),
            asyncResult =>
            {
                try
                {
                    string translatedText =
                    client.EndTranslate(asyncResult);
                    subject.OnNext(translatedText);
                    subject.OnCompleted();
                }
                catch (Exception ex)
                {
                    subject.OnError(ex);
                }
            }, null);
            // This actually returns immediately, before the translate finishes!
            return subject;
            //return default;
        }
        static IObservable<string> TranslateToSpanishAsync(this LanguageServiceClient client, string englishText, string nothing)
        {
            Func<TranslateRequest, IObservable<string>> translateFunc =
            Observable.FromAsyncPattern<TranslateRequest, string>(default /*client.BeginTranslate*/, client.EndTranslate);
            const string appId = "YourAppIdHere";
            return translateFunc( new TranslateRequest(appId, englishText, "en", "es"));
        }
    }

    internal class TranslateRequest
    {
        private string appId;
        private string englishText;
        private string v1;
        private string v2;

        public TranslateRequest(string appId, string englishText, string v1, string v2)
        {
            this.appId = appId;
            this.englishText = englishText;
            this.v1 = v1;
            this.v2 = v2;
        }
    }

    internal class LanguageServiceClient
    {
        internal void BeginTranslate(TranslateRequest translateRequest, Action<object> p1, object p2)
        {
            throw new NotImplementedException();
        }

        internal string EndTranslate(object asyncResult)
        {
            throw new NotImplementedException();
        }
    }
}
