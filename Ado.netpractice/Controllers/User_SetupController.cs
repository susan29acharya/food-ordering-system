using Ado.netpractice.Models;
using Ado.netpractice.Services.User_Setup;
using Azure;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Ado.netpractice.Controllers
{
    public class User_SetupController : Controller
    {
        public readonly IUser_setup User_Setup;

        public User_SetupController(IUser_setup UserSetup)
        {
            User_Setup = UserSetup;
        }

        [HttpGet]
        public IActionResult User_Signup()
        {
            return View();
        }
        [HttpPost]
        public IActionResult User_Signup(UserSignup Userproperty)
        {
            var response = User_Setup.Users_Signup(Userproperty);
            return Json(new { message = response.ResponseMessage,code = response.ResponseCode });
        }
        [HttpGet]
        public IActionResult User_Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult User_Login(UserResponseModel Userproperty)
        {
            var response = User_Setup.Users_Login(Userproperty);

            var claims = new List<Claim> {
            new Claim("Username",response.UserName),
            new Claim("Password",response.Pwd)   
            };
            var claimIdentity = new ClaimsIdentity(claims);
            HttpContext.SignInAsync(new ClaimsPrincipal(claimIdentity));

            return Json(new { message = response.ResponseMessage, code = response.ResponseCode });
        }

    }
}
