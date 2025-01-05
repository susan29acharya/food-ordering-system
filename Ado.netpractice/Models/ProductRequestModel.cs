using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Ado.netpractice.Models
{
    public class ProductRequestModel
    {
        public string? ItemName { get; set; }
        public string ProductId { get; set; }
        public string? Price { get; set; }
        public string? PurchasePrice { get; set; }
        public string? SellingPrice { get; set; }
        public string? Unit { get; set; }
        public string? Description { get; set; }
        public string? Flag { get; set; }
        public string? TableNo { get; set; }
        public string? Amount { get; set; }
        public string? Quantity { get; set; }
        public string? RowId { get; set; }
        public string? TotalAmount { get; set; }
        public string? TableId { get; set; }
        public string? TableName { get; set; }
        public string? Status { get; set; }
        public IFormFile? formFile { get; set; }
        public string? ImagePath { get; set; }

    }
    public class ProductListModel
    {
        public List<ProductRequestModel> productList { get; set; }

    }
}
