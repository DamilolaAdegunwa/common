using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Publico.Data;
using Publico.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Publico.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly UserManager<AppUser> _userManager;
        private readonly IHttpContextAccessor _httpContext;
        public HomeController(ILogger<HomeController> logger, 
            ApplicationDbContext applicationDbContext, 
            UserManager<AppUser> userManager,
            IHttpContextAccessor httpContext)
        {
            _logger = logger;
            _applicationDbContext = applicationDbContext;
            _userManager = userManager;
            _httpContext = httpContext;
        }

        public async Task<IActionResult> Index()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if(User.Identity.IsAuthenticated)
            {
                ViewBag.CurrentUser = currentUser.UserName;
                ViewBag.CurrentUserId = currentUser.Id;
            }
            
            var messages = await _applicationDbContext.Messages.ToListAsync();
            return View(messages);
        }

        public async Task<IActionResult> Create(Message message)
        {
            if(ModelState.IsValid)
            {
                var currentUser = await _userManager.GetUserAsync(User);
                //message.UserName = currentUser.UserName;
                message.UserId = currentUser.Id;
                message.When = DateTimeOffset.Now;
                _ = await _applicationDbContext.Messages.AddAsync(message);
                _ = await _applicationDbContext.SaveChangesAsync();
                return Ok();
            }
            return Error();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [AllowAnonymous]
        public async Task<IActionResult> Start()
        {
            return View();
        }

    }
}
