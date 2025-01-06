using Ado.netpractice.Models;
using global::Ado.netpractice.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Ado.netpractice.Services.Claims;

namespace Ado.netpractice.Controllers
{
    public class ProductController : Controller
    {
        public readonly IServiceDbConnection _productdal;
       

        public ProductController(IServiceDbConnection productDal)
        {
            _productdal = productDal;
           
        }
        public IActionResult Index()
        {
            var a = HttpContext.GetClaimsData();
            ViewBag.a = a.username;
            return View();
           
        }
        
        public IActionResult GetProductList()
        {
            return View();
        }
        //inserting data into database

        [HttpPost]
        public IActionResult InsertProductList(ProductRequestModel produtdtls)
        {
            var response = _productdal.Insert_Product(produtdtls);
               
                if (response)
                {     
                    return Json(response);
                }
            // If model validation fails, return to the form with errors
            return View(produtdtls);
        }

        //fetching data from database 
        [HttpGet]
        public IActionResult fetchingdata()
        {
            var ProductDataList = _productdal.Fetching_Data();
            return Json(new {success = true, data = ProductDataList });
        }
        //deleting data using id
        [HttpPost]
        public IActionResult Deleted(int Id)
        {
            var deleted = _productdal.Delete_Product(Id);
            if (deleted)
            {
                return Json(new {success=true});
            }
            else
            {
                return Json(new {success = false });
            }
        }
        //editing data using id
        public IActionResult Edit(ProductRequestModel request)
        {
            var fetched_data = _productdal.Fetching_DataForEdit(request);
            //var stored_data = fetched_data.productList.FirstOrDefault(p => p.ProductId == id);
            return Json(fetched_data);
        }

        [HttpPost]
        public IActionResult Editing(int id, ProductRequestModel prop)
        {
            var result = _productdal.Edit_Product(id,prop);
            if (result)
            {
                return Json(new { success = true });
            }
            else
            {
                return Json(new { success = false });
            }
        }

        [HttpGet]
        public IActionResult Product_Search()
        {
            var ab = HttpContext.GetClaimsData();
            ViewBag.ab = ab.username;
            return View();
        }

        [HttpPost]
        //action to for searching product
        public IActionResult Product_Search(string Itemnames)
        {
            
            var result = _productdal.Product_Search(Itemnames);
            return Json(result);
        }

        [HttpPost]
        //action for ordered_list
        public IActionResult Add_Order_into_List(ProductRequestModel request)
        {

            var result = _productdal.Add_Order_into_List(request);
            return Json(result);
        }
        [HttpPost]
        public IActionResult UpdateQuantity(ProductRequestModel request)
        {
            var response = _productdal.Row_QuantityUpdate(request);

            return Json(response);
        }

        [HttpPost]
        public IActionResult DeleteItemRow(ProductRequestModel request)
        {
            var response = _productdal.DeleteItemRow(request);
            return Json(response);
        }


    }
}
