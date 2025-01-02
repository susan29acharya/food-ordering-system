using Ado.netpractice.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Ado.netpractice.Services.User_Setup
{
    public class User_Setup : IUser_setup
    {
        public readonly IConfiguration _configuration;
        public User_Setup( IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string connstring()
        {
          var connstring =  _configuration.GetConnectionString("dbcs");
            return connstring;
        }

        public UserResponseModel Users_Signup(UserSignup Userproperty)
        {
            UserResponseModel response=new UserResponseModel();

            using (SqlConnection conn = new SqlConnection(connstring()))
            {
                SqlCommand cmd = new SqlCommand("SP_User_Setup", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserName", Userproperty.UserName);
                cmd.Parameters.AddWithValue("@Pwd", Userproperty.Pwd);
                cmd.Parameters.AddWithValue("@FirstName", Userproperty.FirstName);
                cmd.Parameters.AddWithValue("@LastName", Userproperty.LastName);
                cmd.Parameters.AddWithValue("@Email", Userproperty.Email);
                cmd.Parameters.AddWithValue("@MobileNo", Userproperty.MobileNo);
                cmd.Parameters.AddWithValue("@flag", "I");
                conn.Open();
                
                using(SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        response.ResponseCode = (int)reader["ResponseCode"];
                        response.ResponseMessage = reader["Responsemessage"].ToString();
                    }
                }
                conn.Close();
               return response;
            }
        }

        public UserResponseModel Users_Login(UserResponseModel Userproperty)
        {
            UserResponseModel response = new UserResponseModel();
            using (SqlConnection conn = new SqlConnection(connstring()))
            {

                SqlCommand cmd = new SqlCommand("SP_User_Setup", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserName", Userproperty.UserName);
                cmd.Parameters.AddWithValue("@Pwd", Userproperty.Pwd);
                cmd.Parameters.AddWithValue("@flag", "Login");
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        response.ResponseCode = (int)reader["Responsecode"];
                        response.ResponseMessage = reader["Responsemessage"].ToString();
                    }
                }
                conn.Close();
                return response;
            }
        }
    }
}
