using Ado.netpractice.Services.Table_Setup;
using Microsoft.AspNetCore.Mvc;

namespace Ado.netpractice.Controllers
{
    public class TableSetupController : Controller
    {
        public readonly ITableSetup _TableSetup;

        public TableSetupController(ITableSetup TableSetup)
        {
            _TableSetup = TableSetup;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Table_Number()
        {
           var TableNumber=_TableSetup.Fetch_TableNumbers();
            return Json(TableNumber);
        }
        [HttpPost]
        public IActionResult Add_Table(string tablename)
        {
            var response = _TableSetup.AddTable(tablename);
           return Json(new {datas = response,code = response.ResponseCode});
        }
        [HttpPost]
        public IActionResult Fetcing_TablenumByID(int Tableid)
        {
            var response = _TableSetup.FetchingTable_ById(Tableid);
            return Json(response);
        }
    }
}
