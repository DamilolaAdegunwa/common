using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Thur.Data;
using Thur.Models;

namespace Thur.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly ApplicationDbContext _applicationDbContext;
        public HomeController(ILogger<HomeController> logger, SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, ApplicationDbContext applicationDbContext)
        {
            _logger = logger;
            _signInManager = signInManager;
            _userManager = userManager;
            _applicationDbContext = applicationDbContext;
        }

        public async Task<IActionResult> Index()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            ViewBag.CurrentUser = currentUser.UserName;
            var messages = await  _applicationDbContext.Messages.ToListAsync();
            return View(messages);
        }
        public async Task<IActionResult> Create(Message message)
        {
            if (ModelState.IsValid)
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
    }
}
