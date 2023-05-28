using Auth.AspNet.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Claims;
//using System.Web.Mvc;
//using System.Web;
namespace Auth.AspNet.MVC.Controllers
{
    public class BaseController : Controller
    {
        public BaseController()
        {
            var s = HttpContext.User.Identity;
        }
       // protected virtual new CustomPrincipal CustomUser
        protected virtual new ClaimsPrincipal CustomUser
        {
            //get { return HttpContext.User as CustomPrincipal; }
            get { return HttpContext.User; }
            //get { return new CustomPrincipal(); }
        }
    }
}