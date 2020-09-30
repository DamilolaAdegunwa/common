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
namespace Auth.AspNet.MVC
{
    public class TestController : Controller
    {
        [System.Web.Mvc.HttpGet, System.Web.Mvc.HttpPost]
        public ActionResult CreateCookie(ViewModel viewModel)
        {
            bool isValid = true;
            if (isValid/*Membership.ValidateUser(viewModel.Email, viewModel.Password)*/)
            {
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

                string encTicket = FormsAuthentication.Encrypt(authTicket);
                HttpCookie faCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
                Response.Cookies.Add(faCookie);

                return RedirectToAction("Index", "Home");
            }
            return View();
        }
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
        #endregion
    }
    #region helper types
    interface ICustomPrincipal : IPrincipal
    {
        int Id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
    }
    public class CustomPrincipal : ICustomPrincipal
    {
        public IIdentity Identity { get; private set; }
        public bool IsInRole(string role) { return false; }

        public CustomPrincipal(string email)
        {
            this.Identity = new GenericIdentity(email);
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    public class CustomPrincipalSerializeModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    #endregion
}