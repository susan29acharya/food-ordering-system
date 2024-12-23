using Ado.netpractice.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ado.netpractice.Services.User_Setup
{
    public interface IUser_setup
    {
        public string connstring();

        public UserResponseModel Users_Signup(UserSignup Userproperty);

        public UserResponseModel Users_Login(UserResponseModel Userproperty);

    }
}
