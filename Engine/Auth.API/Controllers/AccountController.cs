using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Web;
//using System.Web.Http;
//using System.Web.Script.Serialization;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using RestSharp;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Cryptography;
using IdentityModel;
using System.Security.Claims;
using System.Security.Principal;
using Microsoft.Owin.Security.DataProtection;
using Microsoft.AspNet.Identity.Owin;
using System.Net.Mail;
//using System.Web.Http.Cors;
//using System.Web.Hosting;
using System.IO;
using System.Collections.Specialized;
using Microsoft.AspNetCore.Cors;
using System.Web.Http;
using Microsoft.Build.Framework;
using System.Data;
namespace Auth.API.Controllers
{
    //[EnableCors(origins: "*", headers: "*", methods: "*")]
    [EnableCors(PolicyName = "")]
    [RoutePrefix("api/account")]
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            new DataSet();
            new DataTable();
            return View();
        }
    }
}