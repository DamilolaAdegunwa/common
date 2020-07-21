using CodeSnippet.ConsoleApp.Services;
using Nito.AsyncEx;
using System;
using System.Collections.Concurrent;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.Remoting;
using System.Runtime;
using System.Diagnostics;
using FireBase.Notification;
using FireBase;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Storage.V1;
using FirebaseAdmin;
using System.IO;
using FirebaseAdmin.Auth;
using System.Net;
using System.Web.Script.Serialization;
using System.Text;
using FirebaseAdmin.Messaging;
//using System.Web.Extensions;
using RestSharp;
using FirebaseAdmin.Auth;
namespace CodeSnippet.ConsoleApp
{
    public class Program
    {
        public readonly static string projectId = "express-dispatch"; //project Id
        public readonly static string path_to_private_key = "C:/Projects/express-dispatch-firebase-adminsdk-gk7qg-a556ad0d32.json";//generated private key
        public readonly static string public_facing_name = "project-985216774624";
        public readonly static string projectName = "Express Dispatch";
        public readonly static string WebAPIKey = "AIzaSyBb6F742Wgp5Q9ysGnMC0ln2rttB8IfUII";
        public readonly static string Server_Key = "AAAA5WN-8eA:APA91bHK1LKIibbKsoELnzn5cXZqCI94sX92fBhIHYcZuxKEuFgzuU8FJiqo6JoEoD5MKgy3q35DuckXJwCtkOEtYUPXBJMBSpadRIv0Uav9-yXoLKyv43ZEWWfuLBvhqGjLabK6X488";
        public readonly static string sender_Id = "985216774624";
        public readonly static string deviceId = "focyYrcwRxu4E7tKl2M6QN:APA91bFT5a8LG5RuI9Jzb_v6-4G7LMOP19r0tXEHIlCGQpmrzQAiUaL8nzWYz9B66fUHWOZvp3TH9EWI4hcbWh6BwTsvrTOWOLUv17kXOlhluJgJoEjBswBgKKmL4Is4Yfe1TMKBi_w2focyYrcwRxu4E7tKl2M6QN:APA91bFT5a8LG5RuI9Jzb_v6-4G7LMOP19r0tXEHIlCGQpmrzQAiUaL8nzWYz9B66fUHWOZvp3TH9EWI4hcbWh6BwTsvrTOWOLUv17kXOlhluJgJoEjBswBgKKmL4Is4Yfe1TMKBi_w2";
        public static async Task Main()
        {
            using (var firebase = new FireBase.Notification.Firebase())
            {
                await firebase.PushNotifyAsync(sender_Id, "Hello", "World");

                FileStream serviceAccount = new FileStream(path_to_private_key, FileMode.Open);// get the content of the file
                var credential = GoogleCredential.FromStream(serviceAccount);// obtain the credential from the file
                serviceAccount.Close();//close the file (release the file handle, and possibly the thread!)
                var storage = StorageClient.Create(credential);//storage details
                
                // Make an authenticated API request.
                //new FCMPushNotification().SendNotification("_title", "_message", "_topic", "deviceId");

                //firebase.PushNotifyAsync(id, "Hello", "World").Wait();
                var buckets = storage.ListBuckets(projectId);//Todo: check why the bucket was empty!
                //buckets
                foreach (var bucket in buckets)
                {
                    Console.WriteLine($"{bucket.Name}::{bucket}");
                }
                //FirebaseInstanceId.getInstance().getToken();
                //try
                //{
                //    FirebaseApp.Create(new AppOptions()
                //    {
                //        Credential = GoogleCredential.GetApplicationDefault(),
                //    });
                //}
                //catch (Exception ex)
                //{

                //}
                try
                {
                    var firebaseApp = FirebaseApp.Create(new AppOptions()
                    {
                        Credential = GoogleCredential.FromFile(path_to_private_key),
                    },"My_Beautiful_App");
                    FirebaseMessaging.GetMessaging(firebaseApp);
                    new FCMPushNotification().SendNotification("title", "message", "topic", deviceId);
                    await new Program().SendNotification(new List<string>() { deviceId, deviceId }, "title", "body: some sort of msg to be sent to a device!");

                }
                catch(FirebaseException fex)
                {

                }
                catch (Exception ex)
                {

                }
                
                //try
                //{
                //    FirebaseApp.Create();
                //    // Initialize the default app
                //    var defaultApp = FirebaseApp.Create("defaultOptions");

                //    // Initialize another app with a different config
                //    var otherApp = FirebaseApp.Create("other");

                //    Console.WriteLine(defaultApp.Name); // "defaultOptions"
                //    Console.WriteLine(otherApp.Name); // "other"

                //    // Use the shorthand notation to retrieve the default app's services
                //    var defaultAuth = FirebaseAuth.DefaultInstance;

                //    // Use the otherApp variable to retrieve the other app's services
                //    var otherAuth = FirebaseAuth.GetAuth(otherApp);

                //}
                //catch (Exception ex)
                //{

                //}
            }
        }
        public virtual async Task<string> SendNotification(List<string> clientToken, string title, string body)
        {
            var registrationTokens = clientToken;
            var message = new MulticastMessage()
            {
                Tokens = registrationTokens,
                Data = new Dictionary<string, string>()
                 {
                     {"title", title},
                     {"body", body},
                 },
            };
            var firebaseApp = FirebaseApp.Create(new AppOptions()
            {
                Credential = GoogleCredential.FromFile(path_to_private_key),
            }, "My_Sexy_App");
            //FirebaseMessaging.GetMessaging(firebaseApp);
            //var response = await FirebaseMessaging.DefaultInstance.SendMulticastAsync(message).ConfigureAwait(true);
            var response = await FirebaseMessaging.GetMessaging(firebaseApp).SendMulticastAsync(message).ConfigureAwait(true);
            var nresp = response.FailureCount + response.SuccessCount;
            var eachResp = response.Responses;
            return "";
        }
        public class FCMPushNotification
        {
            public FCMPushNotification()
            {
                // TODO: Add constructor logic here  
            }
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
            public FCMPushNotification SendNotification(string title, string message, string topic, string deviceId)
            {
                FCMPushNotification result = new FCMPushNotification();
                try
                {
                    result.Successful = true;
                    result.Error = null; 
                    string serverKey = Server_Key;
                    string senderId = sender_Id;
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
                    request.AddBody(data);
                    IRestResponse response = client.Execute(request);
                    var content = response.Content;
                    var resultStatusCode = response.StatusCode;
                    //return result;
                    #region WeRequest Implementation
                    //WebRequest webRequest = WebRequest.Create(requestUri);
                    //webRequest.Method = "POST";
                    //webRequest.Headers.Add(string.Format("Authorization: key={0}", serverKey));
                    //webRequest.Headers.Add(string.Format("Sender: id={0}", senderId));
                    //webRequest.ContentType = "application/json";
                    //var data = new
                    //{
                    //    to = deviceId, // this if you want to test for a single device  
                    //                   //to = "/topics/" + _topic, // this is for topic  
                    //    priority = "high",
                    //    notification = new
                    //    {
                    //        title = _title,
                    //        body = _message,
                    //        show_in_foreground = "True",
                    //        icon = "myicon"
                    //    }
                    //};
                    //var serializer = new JavaScriptSerializer();
                    //var json = serializer.Serialize(data);
                    //Byte[] byteArray = Encoding.UTF8.GetBytes(json);
                    //webRequest.ContentLength = byteArray.Length;
                    //using (Stream dataStream = webRequest.GetRequestStream())
                    //{
                    //    dataStream.Write(byteArray, 0, byteArray.Length);
                    //    using (WebResponse webResponse = webRequest.GetResponse())
                    //    {
                    //        using (Stream dataStreamResponse = webResponse.GetResponseStream())
                    //        {
                    //            using (StreamReader tReader = new StreamReader(dataStreamResponse))
                    //            {
                    //                String sResponseFromServer = tReader.ReadToEnd();
                    //                result.Response = sResponseFromServer;
                    //            }
                    //        }
                    //    }
                    //}
                    #endregion
                }
                catch (Exception ex)
                {
                    result.Successful = false;
                    result.Response = null;
                    result.Error = ex;
                }
                return result;
            }
        }
    }
}