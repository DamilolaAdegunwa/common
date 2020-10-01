using Auth.AspNet.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Principal;
using Microsoft.AspNet.Identity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Owin.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
//using Microsoft.IdentityModel.Tokens;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataProtection;
//using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.Entity;
//using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;
using System.Web.Http;
//using System.Web.Http.Cors;
using System.Web.Script.Serialization;
namespace Auth.AspNet.MVC.Controllers
{
    public class TestController : BaseController//Controller
    {
        [System.Web.Mvc.HttpGet, System.Web.Mvc.HttpPost]
        public ActionResult CreateCookieFromUser(ViewModel viewModel)
        {
            //HttpRuntime.;
            
            bool isValid = true;
            if (isValid/*Membership.ValidateUser(viewModel.Email, viewModel.Password)*/)
            {//for anonymous user set Email= "";
                CustomPrincipal user = default;//userRepository.Users.Where(u => u.Email == viewModel.Email).First();

                CustomPrincipalSerializeModel serializeModel = new CustomPrincipalSerializeModel();
                serializeModel.Id = user.Id;
                serializeModel.FirstName = user.FirstName;
                serializeModel.LastName = user.LastName;

                JavaScriptSerializer serializer = new JavaScriptSerializer();

                string userData = serializer.Serialize(serializeModel);

                FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
                         1,
                         viewModel.Email,
                         DateTime.Now,
                         DateTime.Now.AddMinutes(15),
                         false,
                         userData);
                var f = new FormsAuthentication();
                
                string encTicket = FormsAuthentication.Encrypt(authTicket);
                HttpCookie faCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
                faCookie.HttpOnly = true;//this prevents javascript from accessing it!!
                Response.Cookies.Add(faCookie);
                //FormsAuthentication.SignOut();//to sign out
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            //Hard Coded for the moment
            var userID = "";
            var username = "";
            bool isValid = true;
            if (isValid)
            {
                string userData = String.Empty;
                userData = userData + "UserID=" + userID;
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, username, DateTime.Now, DateTime.Now.AddMinutes(30), true, userData);
                string encTicket = FormsAuthentication.Encrypt(ticket);
                HttpCookie faCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
                Response.Cookies.Add(faCookie);
                //And send the user where they were heading
                string redirectUrl = FormsAuthentication.GetRedirectUrl(username, false);
                Response.Redirect(redirectUrl);
            }
        }
        protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
        {//get user from cookie
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];

            if (authCookie != null)
            {
                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);

                JavaScriptSerializer serializer = new JavaScriptSerializer();

                CustomPrincipalSerializeModel serializeModel = serializer.Deserialize<CustomPrincipalSerializeModel>(authTicket.UserData);

                CustomPrincipal newUser = new CustomPrincipal(authTicket.Name);
                newUser.Id = serializeModel.Id;
                newUser.FirstName = serializeModel.FirstName;
                newUser.LastName = serializeModel.LastName;

                HttpContext.User = newUser;

                /*
                @((User as CustomPrincipal).Id)
                @((User as CustomPrincipal).FirstName)
                @((User as CustomPrincipal).LastName) 

                (User as CustomPrincipal).Id
                (User as CustomPrincipal).FirstName
                (User as CustomPrincipal).LastName

                Hash hash = new Hash("SHA256");
                if(u.Password == hash.Encrypt(EnteredTyped))

                else {HttpContext.Current.User = new CustomPrincipal(""); };if (authCookie != null) {     //.. }
                */
            }
        }
        protected void Application_AuthenticateRequest(Object sender, EventArgs e)
        {
            HttpCookie authCookie = Request.Cookies[
                     FormsAuthentication.FormsCookieName];
            if (authCookie != null)
            {
                //Extract the forms authentication cookie
                FormsAuthenticationTicket authTicket =
                       FormsAuthentication.Decrypt(authCookie.Value);
                // Create an Identity object
                //CustomIdentity implements System.Web.Security.IIdentity
                //=>CustomIdentity id = GetUserIdentity(authTicket.Name);
                //CustomPrincipal implements System.Web.Security.IPrincipal
                CustomPrincipal newUser = new CustomPrincipal("");
                HttpContext.User = newUser;
            }
        }
        public void HelperCreateCookies()
        {
            int version = 1;
            DateTime now = DateTime.Now;

            // respect to the `timeout` in Web.config.
            TimeSpan timeout = FormsAuthentication.Timeout;
            DateTime expire = now.Add(timeout);
            bool isPersist = false;

            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                 version,
                 "name",
                 now,
                 expire,
                 isPersist,
                 "userData");
            HttpCookie faCookie = new HttpCookie(FormsAuthentication.FormsCookieName, "encTicket");
            // respect to `RequreSSL` in `Web.Config`
            bool bSSL = FormsAuthentication.RequireSSL;
            faCookie.Secure = bSSL;
        }
        #region last create - and - check for cookies impl
        public class UserExBusinessInfo
        {
            public int BusinessID { get; set; }
            public string Name { get; set; }
        }

        public class UserExInfo
        {
            public IEnumerable<UserExBusinessInfo> BusinessInfo { get; set; }
            public int? CurrentBusinessID { get; set; }
        }

        public class PrincipalEx : ClaimsPrincipal
        {
            private readonly UserExInfo userExInfo;
            public UserExInfo UserExInfo => userExInfo;

            public PrincipalEx(IPrincipal baseModel, UserExInfo userExInfo)
                : base(baseModel)
            {
                this.userExInfo = userExInfo;
            }
        }

        public class PrincipalExSerializeModel
        {
            public UserExInfo UserExInfo { get; set; }
        }

        public static class IPrincipalHelpers
        {
            //public static UserExInfo ExInfo(this IPrincipal @this) => (@this as PrincipalEx)?.UserExInfo;
        }


        [System.Web.Mvc.HttpPost]
        [System.Web.Mvc.AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginModel details, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                //AppUser user = await UserManager.FindAsync(details.Name, details.Password);

                if (false/*user == null*/)
                {
                    ModelState.AddModelError("", "Invalid name or password.");
                }
                else
                {
                    /*works with little modification*/
                    //ClaimsIdentity ident = await UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
                    ////var manager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
                    ////UserManager<IdentityUser>
                    ////HttpContext.
                    //AuthManager.SignOut();
                    //AuthManager.SignIn(new AuthenticationProperties { IsPersistent = false }, ident);

                    //user.LastLoginDate = DateTime.UtcNow;
                    //await UserManager.UpdateAsync(user);

                    //PrincipalExSerializeModel serializeModel = new PrincipalExSerializeModel();
                    //serializeModel.UserExInfo = new UserExInfo()
                    //{
                    //    BusinessInfo = await
                    //        db.Businesses
                    //        .Where(b => user.Id.Equals(b.AspNetUserID))
                    //        .Select(b => new UserExBusinessInfo { BusinessID = b.BusinessID, Name = b.Name })
                    //        .ToListAsync()
                    //};

                    //JavaScriptSerializer serializer = new JavaScriptSerializer();

                    //string userData = serializer.Serialize(serializeModel);

                    //FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
                    //         1,
                    //         details.Name,
                    //         DateTime.Now,
                    //         DateTime.Now.AddMinutes(15),
                    //         false,
                    //         userData);

                    //string encTicket = FormsAuthentication.Encrypt(authTicket);
                    //HttpCookie faCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
                    //Response.Cookies.Add(faCookie);

                    //return RedirectToLocal(returnUrl);
                    return View();
                }
            }
            return View(details);
        }

        protected void Application_PostAuthenticateRequest2(Object sender, EventArgs e)
        {
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];

            if (authCookie != null)
            {
                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                PrincipalExSerializeModel serializeModel = serializer.Deserialize<PrincipalExSerializeModel>(authTicket.UserData);
                PrincipalEx newUser = new PrincipalEx(HttpContext.User, serializeModel.UserExInfo);
                HttpContext.User = newUser;
            }
        }
        #endregion
        #region other action methods
        public class ViewModel
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }

        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }

        public class LoginModel
        {
        }
        #endregion
    }
    public static class UserHelpers
    {
        public static bool IsEditor(this IPrincipal user)
        {
            return true; //Do some stuff
        }
    }
}