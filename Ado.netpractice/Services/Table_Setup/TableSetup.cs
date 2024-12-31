using Ado.netpractice.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Data;

namespace Ado.netpractice.Services.Table_Setup
{

    public class TableSetup : ITableSetup
    {
        public readonly IConfiguration _configuration;
        public TableSetup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string connstring()
        {
            var constring = _configuration.GetConnectionString("dbcs");
            return constring;
        }
        public List<TableNumber_Setup> Fetch_TableNumbers()
        {
            List<TableNumber_Setup> TableNumbers = new List<TableNumber_Setup>();

            using (SqlConnection conn = new SqlConnection(connstring()))
            {
                SqlCommand cmd = new SqlCommand("Sp_Resturant_TableSetup", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@flag", "FetchTable");

                conn.Open();

                SqlDataAdapter dadapter = new SqlDataAdapter(cmd);

                DataTable dtable = new DataTable();

                dadapter.Fill(dtable);

                foreach (DataRow dr in dtable.Rows)
                {
                    TableNumber_Setup TableList = new TableNumber_Setup
                    {
                        TableId = (int)dr["TableId"],
                        TableNumber = dr["TableNumber"].ToString(),
                        Status = dr["STATUS"].ToString()
                    };
                    TableNumbers.Add(TableList);
                }
                return TableNumbers;
            };
        }

        public TableNumber_Setup AddTable(string tablename)
        {
            TableNumber_Setup tableprop = new TableNumber_Setup();
            using (SqlConnection conn = new SqlConnection(connstring()))
            {
                SqlCommand cmd = new SqlCommand("Sp_Resturant_TableSetup", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@flag", "AddTable");
                cmd.Parameters.AddWithValue("@TableNumber", tablename);
                conn.Open();

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    if (rdr.Read())
                    {
                        tableprop.ResponseCode = (int)rdr["ResponseCode"];
                    }
                };
            }
            return tableprop;
        }

        public List<TableNumber_Setup> FetchingTable_ById(int Tableid)
        {
            List<TableNumber_Setup> tableNumbers = new List<TableNumber_Setup>();
            using (SqlConnection conn = new SqlConnection(connstring()))
            {
                SqlCommand cmd = new SqlCommand("Sp_Resturant_TableSetup", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@flag", "SelectTable");
                cmd.Parameters.AddWithValue("@TableId", Tableid);
                conn.Open();

                SqlDataAdapter dadapter = new SqlDataAdapter(cmd);

                DataTable dtable = new DataTable();

                dadapter.Fill(dtable);

                foreach (DataRow dr in dtable.Rows)
                {
                    TableNumber_Setup prop = new TableNumber_Setup
                    {
                        TableNumber = dr["TableNumber"].ToString()
                        
                    };
                    tableNumbers.Add(prop);                  
                }
                return tableNumbers;
            };
        }
    }
}
