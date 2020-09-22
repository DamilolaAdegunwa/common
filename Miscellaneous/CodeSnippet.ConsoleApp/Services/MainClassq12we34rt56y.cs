using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace CodeSnippet.ConsoleApp
{
    public class MainClass
    {
        public static void Main2()
        {

            new MainClass().SendNotification("TITLE FROM THE ...", "MESSAGE FROM THE ...", Constant.deviceId);
            Console.WriteLine("pls help!!");
        }
        public FCMPushNotification SendNotification(string title, string message, string deviceId)
        {
            FCMPushNotification result = new FCMPushNotification();
            try
            {
                result.Successful = true;
                result.Error = null;
                string serverKey = Constant.FCM_Express_Dispatch_Server_Key;
                string senderId = Constant.FCM_Express_Dispatch_Sender_Id;
                var requestUri = "https://fcm.googleapis.com/fcm/send";

                RestClient client = new RestClient(requestUri);
                RestRequest request = new RestRequest()
                {
                    Method = Method.POST,
                    RequestFormat = DataFormat.Json
                };
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("Authorization", $"key={serverKey}");
                request.AddHeader("Sender", $"id={senderId}");

                var data = new
                {
                    to = deviceId,
                    priority = "high",
                    notification = new
                    {
                        title = title,
                        body = message,
                        show_in_foreground = "true",
                        icon = "myicon"
                    }
                };
                request.AddJsonBody(data);
                IRestResponse response = client.Execute(request);
                result.Response = response.Content;
                result.StatusCode = response.StatusCode;
            }
            catch (Exception ex)
            {
                result.Successful = false;
                result.Response = null;
                result.Error = ex;
            }
            return result;
        }
        public class FCMPushNotification
        {
            public bool Successful
            {
                get;
                set;
            }
            public string Response
            {
                get;
                set;
            }
            public Exception Error
            {
                get;
                set;
            }
            public HttpStatusCode StatusCode { get; set; }
        }
        public class Constant
        {
            #region Dispatch Rider Configuration For Firebase
            public const string FCM_Express_Dispatch_Server_Key = "AAAA5WN-8eA:APA91bHK1LKIibbKsoELnzn5cXZqCI94sX92fBhIHYcZuxKEuFgzuU8FJiqo6JoEoD5MKgy3q35DuckXJwCtkOEtYUPXBJMBSpadRIv0Uav9-yXoLKyv43ZEWWfuLBvhqGjLabK6X488";
            public const string FCM_Express_Dispatch_Sender_Id = "985216774624";
            public const string deviceId = "cFa4Nsf5Ra2S5eIRzb-I8N:APA91bGbY8vadiScZN2JWX8aZL91xJdC3ot08t0CHZJ9Hzl3DjgALUj3mkGwnaWmHER6XLam6mHP51hVbzEz1YgjQG9FE2DpFHl3AwN8G9FIXpU7gCDqPTxy1enSrxiup49zuPPfejx7";
            #endregion
        }
    }
}
