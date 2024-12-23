using Ado.netpractice.Models;
using Ado.netpractice.Services.User_Setup;
using Azure;
using Microsoft.AspNetCore.Mvc;

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
            return Json(new { message = response.ResponseMessage, code = response.ResponseCode });
        }

    }
}
