using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Web.Mvc;

namespace Metronics.ASPNETCore.Web.Controllers
{
    public class HomeController : AsyncController
    {
        public IActionResult Index()
        {
            return default;
        }
        public IActionResult Error()
        {
            return default;
        }
    }
}