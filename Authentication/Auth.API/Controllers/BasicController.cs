using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.AzureAD.UI;
using Microsoft.AspNetCore.Authentication.Facebook;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.MicrosoftAccount;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authentication.Twitter;
using Microsoft.AspNetCore.DataProtection.AzureStorage;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.Owin;
using Polly;
using Polly.Extensions.Http;
using Microsoft.Extensions.Http;
using Auth.API.Services;
namespace Auth.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class BasicController : ControllerBase
    {
        private readonly IFileService _fileService;
        public BasicController(IFileService fileService)
        {
            _fileService = fileService;
            //new Microsoft.Extensions.Http.Polly.
        }
        [HttpGet, Route("get")]
        public async Task<string> GetFileContents()
        {
            var resp = await _fileService.GetFileContents("token.txt");
            return resp;
        }
        //I'd be writting some cool stuff here!!
    }
}