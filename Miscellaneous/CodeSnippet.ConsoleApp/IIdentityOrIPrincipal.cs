using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;
using System.Web.Script.Serialization;
using System.Web.Security;
using System.Web;
namespace CodeSnippet.ConsoleApp
{
    /// <summary>
    /// <para>this class use the <c>System.Web.Script.Serialization</c> a whole lot!</para>
    /// </summary>
    public class IIdentityOrIPrincipal
    {
        public object CreateCookie(ViewModel viewModel)
        {
            if (true/*Membership.ValidateUser(viewModel.Email, viewModel.Password)*/)
            {
                CustomPrincipal user = default;//userRepository.Users.Where(u => u.Email == viewModel.Email).First();

                CustomPrincipalSerializeModel serializeModel = new CustomPrincipalSerializeModel();
                serializeModel.Id = user.Id;
                serializeModel.FirstName = user.FirstName;
                serializeModel.LastName = user.LastName;

                JavaScriptSerializer serializer = new JavaScriptSerializer();

                string userData = serializer.Serialize(serializeModel);

                //FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
                //         1,
                //         viewModel.Email,
                //         DateTime.Now,
                //         DateTime.Now.AddMinutes(15),
                //         false,
                //         userData);

                //string encTicket = FormsAuthentication.Encrypt(authTicket);
                //HttpCookie faCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
                //Response.Cookies.Add(faCookie);

                //return RedirectToAction("Index", "Home");
            }
            return default;
        }

        public class ViewModel
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }
    }
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

        /// <summary>
        /// get the Id in question
        /// </summary>
        /// <value>this is the Id and is of type <c>int</c></value>
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
