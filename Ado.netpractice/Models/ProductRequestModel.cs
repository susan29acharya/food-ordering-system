using System.ComponentModel.DataAnnotations;

namespace Ado.netpractice.Models
{
    public class ProductRequestModel
    {
        public string? ItemName { get; set; }       
        public string ProductId { get; set; }     
        public int? Price { get; set; }      
        public int? PurchasePrice { get; set; }
        public int? SellingPrice { get; set; }      
        public int? Unit { get; set;}
        public string? Description { get; set; }
        public string? Flag { get; set; }
        public int ? Amount { get; set; }
        public double? Quantity { get; set;}
        public string? RowId { get; set; }
        public double? TotalAmount { get; set; }
        public int TableId { get; set; }
    }
    public class ProductListModel
    {
        public List<ProductRequestModel> productList { get; set; }

    }
}
