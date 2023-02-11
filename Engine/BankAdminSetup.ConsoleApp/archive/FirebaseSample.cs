using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirebaseAdmin;
using System.IO;
using RestSharp;
using System.Net;

namespace CodeSnippet.ConsoleApp
{
    /// <summary>
    /// Firebase Sample Class
    /// </summary>
    public class FirebaseSample
    {
        public static void MainTest()
        {
            new FirebaseSample().SendNotification("test", "sample message");
        }
        //public void FirebaseAdminSDKConfiguration()
        //{
        //    FileInputStream serviceAccount = new FileInputStream("path/to/serviceAccountKey.json");

        //    FirebaseOptions options = new FirebaseOptions.Builder()
        //      .setCredentials(GoogleCredentials.fromStream(serviceAccount))
        //      .setDatabaseUrl("https://ekihire-project-default-rtdb.firebaseio.com")
        //      .build();

        //    FirebaseApp.initializeApp(options);
        //    FirebaseApp;
        //}
        public FCMPushNotificationResponseModel SendNotification(string title, string message, string deviceId = "test", string serverKey = null, string senderId = null)
        {
            FCMPushNotificationResponseModel result = new FCMPushNotificationResponseModel();
            try
            {
                result.Successful = true;
                result.Error = null;
                //string serverKey = Constant.FCM_Express_Dispatch_Server_Key;
                //string senderId = Constant.FCM_Express_Dispatch_Sender_Id;
                serverKey = serverKey??"AAAAwLXZJh8:APA91bFUgy47wxZK - 1tzmY7cGL8NVNWLqzAQO5S8ZnMtxzAr8yCUzw_7Ign_G36yItAgY2h74YbVHAjDzP3793sYbZ22Qdi_byEBynnJn4A4m - VaL8Z_EWzv9Vc7_r1QhRfDXIiUng5U";
                senderId = senderId??"827684627999";

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
        
    }
    //public class FirebaseCloudMessagingModel
    //{
    //    public string DeviceId { get; set; }
    //    public DeviceType DeviceType { get; set; }
    //}
    public class FCMPushNotificationResponseModel
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
    //public class FCMPushNotificationRequestModel
    //{
    //    public string Title { get; set; }
    //    public string Message { get; set; }
    //    public string DeviceId { get; set; }
    //    public string ServerKey { get; set; }
    //    public string SenderId { get; set; }
    //    //additions

    //}
}
