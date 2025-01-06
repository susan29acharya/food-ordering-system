using System.Security.Claims;

namespace Ado.netpractice.Services.Claims
{
    public static class Claims
    {
        public static Models.claimsData GetClaimsData(this HttpContext context)
        {
            var claimIdentity = context.User.Identity as ClaimsIdentity;
            var model = new Models.claimsData();

            if (claimIdentity.IsAuthenticated)
            {
                model.username = claimIdentity.FindFirst(x => x.Type == "Username").Value;             
            }
            return model;
        }
    }
}
