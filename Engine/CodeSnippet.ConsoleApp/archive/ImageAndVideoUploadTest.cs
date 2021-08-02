using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using System.IO;
namespace CodeSnippet.ConsoleApp
{
    public class ImageAndVideoUploadTest
    {
        public static void MainImageAndVideoUploadTest()
        {
            byte[] x = default;
            new MemoryStream(Convert.FromBase64String(""));
            new CloudinaryDotNetClass().sampleFile();
            //new GoogleDriveAPITest().Authorize();
        }
    }
    public class CloudinaryDotNetClass
    {
        public const string CLOUD_NAME = "dammy-developer"; 
        public const string API_KEY = "383445738942894"; 
        public const string API_SECRET = "MZ-ZZVxj8vQVaGP_iFN-2O0NyCU"; 
        public const string API_ENVIRONMENT_VARIABLE = "CLOUDINARY_URL=cloudinary://383445738942894:MZ-ZZVxj8vQVaGP_iFN-2O0NyCU@dammy-developer"; 
        public CloudinaryDotNetClass()
        {
            //Account account = new Account(
            //    CLOUD_NAME,//"my_cloud_name",
            //    API_KEY,//"my_api_key",
            //    API_SECRET//"my_api_secret"
            //);

            //Cloudinary cloudinary = new Cloudinary(account);
            //cloudinary.Api.Secure = true;
        }
        public void sampleFile()
        {
            byte[] byteArray = System.IO.File.ReadAllBytes(@"C:\images\cow.png");
            System.IO.MemoryStream stream = new System.IO.MemoryStream(byteArray);
            UploadPhoto(stream);
        }
        public string UploadPhoto(Stream stream)
        {
            Account account = new Account(
             CLOUD_NAME,
              API_KEY,
             API_SECRET);

            Cloudinary cloudinary = new Cloudinary(account);
            var uploadParams = new CloudinaryDotNet.Actions.ImageUploadParams()
            {
                File = new CloudinaryDotNet.FileDescription(Guid.NewGuid().ToString(), stream),
            };

            ImageUploadResult uploadResult = cloudinary.Upload(uploadParams);
            //var result = cloudinary.Api.UrlImgUp.BuildUrl(String.Format("ekihire_img{0}.{1}", uploadResult.PublicId, uploadResult.Format));
            var result = uploadResult.Url.ToString();
            return result;
        }
    }
    public class GoogleDriveAPITest
    {
        
        public void Authorize()
        {
            string[] scopes = new string[] { DriveService.Scope.Drive,
                               DriveService.Scope.DriveFile,};
            //var clientId = "12345678-kiwwjelkrklsjdkljklaflkjsdjasdkhw.apps.googleusercontent.com";      // From https://console.developers.google.com  
            //var clientSecret = "ksdklfklas2lskj_asdklfjaskla-";          // From https://console.developers.google.com  

            var clientId = "117568527884477125162";
            var clientSecret = "ekihire-project-service-accoun@ekihire-project-2021.iam.gserviceaccount.com";

            // here is where we Request the user to give us access, or use the Refresh Token that was previously stored in %AppData%  
            var credential = GoogleWebAuthorizationBroker.AuthorizeAsync(new ClientSecrets
            {
                ClientId = clientId,
                ClientSecret = clientSecret
            }, scopes,
            Environment.UserName, CancellationToken.None, new FileDataStore("MyAppsToken")).Result;
            //Once consent is recieved, your token will be stored locally on the AppData directory, so that next time you wont be prompted for consent.   

            DriveService service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "MyAppName",

            });
            service.HttpClient.Timeout = TimeSpan.FromMinutes(100);
            //Long Operations like file uploads might timeout. 100 is just precautionary value, can be set to any reasonable value depending on what you use your service for  

            // team drive root https://drive.google.com/drive/folders/0AAE83zjNwK-GUk9PVA   

            var resp = uploadFile(service, @"C:\test.txt", "");
            // Third parameter is empty it means it would upload to root directory, if you want to upload under a folder, pass folder's id here.
            //MessageBox.Show("Process completed--- Response--" + respocne);
        }
        public Google.Apis.Drive.v3.Data.File uploadFile(DriveService _service, string _uploadFile, string _parent, string _descrp = "Uploaded with .NET!")
        {
            if (System.IO.File.Exists(_uploadFile))
            {
                Google.Apis.Drive.v3.Data.File body = new Google.Apis.Drive.v3.Data.File();
                body.Name = System.IO.Path.GetFileName(_uploadFile);
                body.Description = _descrp;
                body.MimeType = "image/jpeg";//GetMimeType(_uploadFile);
                // body.Parents = new List<string> { _parent };// UN comment if you want to upload to a folder(ID of parent folder need to be send as paramter in above method)
                byte[] byteArray = System.IO.File.ReadAllBytes(_uploadFile);
                System.IO.MemoryStream stream = new System.IO.MemoryStream(byteArray);
                try
                {
                    FilesResource.CreateMediaUpload request = _service.Files.Create(body, stream, "image/jpeg");//GetMimeType(_uploadFile)
                    request.SupportsTeamDrives = true;
                    // You can bind event handler with progress changed event and response recieved(completed event)
                    request.ProgressChanged += Request_ProgressChanged;
                    request.ResponseReceived += Request_ResponseReceived;
                    request.Upload();
                    return request.ResponseBody;
                }
                catch (Exception e)
                {
                    //MessageBox.Show(e.Message, "Error Occured");
                    return null;
                }
            }
            else
            {
                //MessageBox.Show("The file does not exist.", "404");
                return null;
            }
        }
        //private static string GetMimeType(string fileName) { 
        //    string mimeType = "application/unknown"; 
        //    string ext = System.IO.Path.GetExtension(fileName).ToLower(); 
        //    Microsoft.Win32.RegistryKey regKey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(ext); 
        //    if (regKey != null && regKey.GetValue("Content Type") != null) 
        //        mimeType = regKey.GetValue("Content Type").ToString(); 
        //    System.Diagnostics.Debug.WriteLine(mimeType); 
        //    return mimeType; 
        //}

        private void Request_ProgressChanged(Google.Apis.Upload.IUploadProgress obj)
        {
            //textBox2.Text += obj.Status + " " + obj.BytesSent;
        }

        private void Request_ResponseReceived(Google.Apis.Drive.v3.Data.File obj)
        {
            if (obj != null)
            {
                //MessageBox.Show("File was uploaded sucessfully--" + obj.Id);
            }
        }
    }
}
