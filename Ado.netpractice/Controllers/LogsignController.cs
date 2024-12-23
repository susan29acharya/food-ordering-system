using Ado.netpractice.Models;
using Ado.netpractice.Services;
using Microsoft.AspNetCore.Mvc;

namespace Ado.netpractice.Controllers
{
    public class LogsignController : Controller
    {
        public readonly IServiceDbConnection _logsign;

        public LogsignController(IServiceDbConnection logsign)
        {
            _logsign = logsign;
        }
        [HttpPost]
        public IActionResult signup(LogSign logdata)
        {
            var signuped = _logsign.Signup(logdata);
            if (signuped)
            {
                return Json(signuped);
            }
            return View(logdata);
        }
    }
}
