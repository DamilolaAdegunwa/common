using Auth.AspNet.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Auth.AspNet.MVC.Controllers
{
    public class BaseController : Controller
    {
        protected virtual new CustomPrincipal CustomUser
        {
            get { return HttpContext.User as CustomPrincipal; }
        }
    }
}