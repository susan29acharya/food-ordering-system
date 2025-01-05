using Ado.netpractice.Models;
using Ado.netpractice.Services;
using Microsoft.Data.SqlClient;
using System.Data;

public class DbConnection : IServiceDbConnection
{
    private readonly IConfiguration _configuration;
  

    public DbConnection(IConfiguration configuration)
    {
        _configuration = configuration;
     
    }

    public string GetUsers()
    {
        var connstring = _configuration.GetConnectionString("dbcs");
        return connstring;
    }

    public bool Insert_Product(ProductRequestModel produtdtls)
    {
        int id = 0;
        var filename = Path.GetFileName(produtdtls.formFile.FileName);
        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/Images", filename);
        using (var stream = new FileStream(path, FileMode.Create))
        {
            produtdtls.formFile.CopyTo(stream);
        }
        produtdtls.ImagePath = Path.Combine("Images", filename);

        using (SqlConnection conn = new SqlConnection(GetUsers()))
        {
            SqlCommand cmd = new SqlCommand("spinsertingdatas", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ItemName", produtdtls.ItemName);
            cmd.Parameters.AddWithValue("@Price", produtdtls.Price);
            cmd.Parameters.AddWithValue("@PurchasePrice", produtdtls.PurchasePrice);
            cmd.Parameters.AddWithValue("@SellingPrice", produtdtls.SellingPrice);
            cmd.Parameters.AddWithValue("@Unit", produtdtls.Unit);
            cmd.Parameters.AddWithValue("@Description", produtdtls.Description);
            cmd.Parameters.AddWithValue("@ImagePath", produtdtls.ImagePath);
            cmd.Parameters.AddWithValue("@flag","I");

            conn.Open();
            id = cmd.ExecuteNonQuery();
            conn.Close();
        }
        if (id > 0)
        {
            return true;
        }
        else
        {
            return false;
        }

    }
    public ProductListModel Fetching_Data()
    {
        //ProductRequestModel list = new ProductRequestModel();
        List<ProductRequestModel> teslit = new List<ProductRequestModel>();
        var ProductListModel = new ProductListModel();

        //creating connection with database
        using (SqlConnection conn = new SqlConnection(GetUsers()))
        {

            //giving sql query and connection
            SqlCommand cmd = new SqlCommand("spinsertingdatas", conn);
            //declaring the command type as it is stored procedure
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "S");

            conn.Open();
            //declaring datareader as it help to read data from database
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable datas = new DataTable();

            da.Fill(datas);

            foreach (DataRow row in datas.Rows)
            {
                ProductRequestModel product = new ProductRequestModel
                {
                    ItemName = row["ItemName"].ToString(),
                    ProductId = row["ProductId"].ToString(),
                    Price = row["Price"].ToString(),
                    PurchasePrice = row["PurchasePrice"].ToString(),
                    SellingPrice = row["SellingPrice"].ToString(),
                    Unit = row["Unit"].ToString(),
                    Description = row["Description"].ToString()
                };

                teslit.Add(product);
            }

            ProductListModel.productList = teslit;
        }
        return ProductListModel;
    }
    public ProductListModel Fetching_DataForEdit(ProductRequestModel request)
    {

        List<ProductRequestModel> teslit = new List<ProductRequestModel>();
        var ProductListModel = new ProductListModel();

        //creating connection with database
        using (SqlConnection conn = new SqlConnection(GetUsers()))
        {

            //giving sql query and connection
            SqlCommand cmd = new SqlCommand("spinsertingdatas", conn);
            //declaring the command type as it is stored procedure
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "SE");
            cmd.Parameters.AddWithValue("@ProductId", request.ProductId);

            conn.Open();
            //declaring datareader as it help to read data from database
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable datas = new DataTable();

            da.Fill(datas);

            foreach (DataRow row in datas.Rows)
            {
                ProductRequestModel product = new ProductRequestModel
                {
                    ItemName = row["ItemName"].ToString(),
                    ProductId = row["ProductId"].ToString(),
                    Price = row["Price"].ToString(),
                    PurchasePrice = row["PurchasePrice"].ToString(),
                    SellingPrice = row["SellingPrice"].ToString(),
                    Unit = row["Unit"].ToString(),
                    Description = row["Description"].ToString()
                };

                teslit.Add(product);
            }

            ProductListModel.productList = teslit;

        }
        return ProductListModel;
    }
    public bool Delete_Product(int Id)
    {
        using (SqlConnection conn = new SqlConnection(GetUsers()))
        {
            SqlCommand cmd = new SqlCommand("spinsertingdatas", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag","D");
            cmd.Parameters.AddWithValue("@ProductId", Id);

            conn.Open();
            int i = cmd.ExecuteNonQuery();

            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public bool Edit_Product(int id, ProductRequestModel prop)
    {
        using (SqlConnection conn = new SqlConnection(GetUsers()))
        {
            SqlCommand cmd = new SqlCommand("spinsertingdatas", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "E");
            cmd.Parameters.AddWithValue("@ProductId", id);
            cmd.Parameters.AddWithValue("@ItemName", prop.ItemName);
            cmd.Parameters.AddWithValue("@Price", prop.Price);
            cmd.Parameters.AddWithValue("@PurchasePrice", prop.PurchasePrice);
            cmd.Parameters.AddWithValue("@SellingPrice", prop.SellingPrice);
            cmd.Parameters.AddWithValue("@Unit", prop.Unit);
            cmd.Parameters.AddWithValue("@Description", prop.Description);

            conn.Open();
            int i = cmd.ExecuteNonQuery();

            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public List<ProductRequestModel> Product_Search(string Itemnames)
    {
        List<ProductRequestModel> list_of_product = new List<ProductRequestModel>();
        using (SqlConnection conn = new SqlConnection(GetUsers()))
        {
            SqlCommand cmd = new SqlCommand("spinsertingdatas", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "P_Search");
            cmd.Parameters.AddWithValue("@ItemName", Itemnames);

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dtable = new DataTable();

            da.Fill(dtable);

            foreach (DataRow row in dtable.Rows)
            {
                ProductRequestModel lists = new ProductRequestModel
                {
                    ProductId = row["ProductId"].ToString(),
                    ItemName = row["ItemName"].ToString(),
                    Price = row["Price"].ToString(),
                    ImagePath = row["ImagePath"].ToString()                   
                };
                list_of_product.Add(lists);
            }
        }
        return list_of_product;
    }
    public List<ProductRequestModel> Add_Order_into_List(ProductRequestModel request)
    {
        List<ProductRequestModel> Order_List = new List<ProductRequestModel>();

        using (SqlConnection conn = new SqlConnection(GetUsers()))
        {
            SqlCommand cmd = new SqlCommand("spinsertingdatas", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            if (!string.IsNullOrEmpty(request.ProductId))
            {
                cmd.Parameters.AddWithValue("@flag", "tempinsert");
            }
            else
            {
                cmd.Parameters.AddWithValue("@flag", "GetTableOrderList");
            }
            cmd.Parameters.AddWithValue("@ProductId", request.ProductId);
            cmd.Parameters.AddWithValue("@TableNo", request.TableId);
            conn.Open();

            SqlDataAdapter sdadapter = new SqlDataAdapter(cmd);

            DataSet dtable = new DataSet();

            sdadapter.Fill(dtable);

            foreach (DataRow dr in dtable.Tables[0].Rows)
            {
                ProductRequestModel lists = new ProductRequestModel
                {
                    RowId = dr["RowId"] != DBNull.Value ? dr["RowId"].ToString() : null,
                    Price = dr["Rate"] != DBNull.Value ? dr["Rate"].ToString() : null,
                    Amount = dr["Amount"].ToString(),
                    Quantity = dr["Quantity"].ToString(),
                    ItemName = dr["ItemName"].ToString(),
                    ProductId = dr["ProductId"].ToString(),
           
                };
                Order_List.Add(lists);
            }
            foreach (DataRow dr in dtable.Tables[1].Rows)
            {
                ProductRequestModel lists = new ProductRequestModel
                {
                    TotalAmount = dr["TotalAmount"].ToString()
                };
                Order_List.Add(lists);
            }

            return Order_List;
        }
    }
    public bool Row_QuantityUpdate(ProductRequestModel request)
    {

        using (SqlConnection conn = new SqlConnection(GetUsers()))
        {
            SqlCommand cmd = new SqlCommand("spinsertingdatas", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@flag", "tempinsert");

            cmd.Parameters.AddWithValue("@Quantity", request.Quantity);
            cmd.Parameters.AddWithValue("@RowId", request.RowId);
            cmd.Parameters.AddWithValue("@ProductId", request.ProductId);
            cmd.Parameters.AddWithValue("@TableNo", request.TableId);

            conn.Open();

            int response = cmd.ExecuteNonQuery();
            if (response > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        };
    }

    public bool DeleteItemRow(ProductRequestModel request)
    {
        using (SqlConnection conn = new SqlConnection(GetUsers()))
        {
            int res = 0;
            conn.Open();
            SqlCommand cmd = new SqlCommand("spinsertingdatas", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@flag", "DeleteItemRow");

            cmd.Parameters.AddWithValue("@RowId", request.RowId);

            res = cmd.ExecuteNonQuery();

            if (res > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        };

    }


}
