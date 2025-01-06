namespace Ado.netpractice.Models
{
    public class UserSignup
    {
        public string UserName { get; set; }
        public string Pwd { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
    }

    public class UserResponseModel:DbResult
    {
        public string UserName { get; set; }
        public string Pwd { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
    }
    public class claimsData
    {
        public string? username { get; set; }
        public string? password { get; set; }
    }                        

}
