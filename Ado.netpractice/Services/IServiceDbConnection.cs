using Ado.netpractice.Models;

namespace Ado.netpractice.Services
{
    public interface IServiceDbConnection
    {
        public string GetUsers();
        public bool Insert_Product(ProductRequestModel products);
        public ProductListModel Fetching_Data();
        public bool Delete_Product(int id);
        public bool Edit_Product(int id,ProductRequestModel prop);
        public ProductListModel Fetching_DataForEdit(ProductRequestModel request);
        public List<ProductRequestModel> Product_Search(string Itemnames);
        public List<ProductRequestModel> Add_Order_into_List(ProductRequestModel request);
        public bool Row_QuantityUpdate(ProductRequestModel request);
        public bool DeleteItemRow(ProductRequestModel request);
    }
}
