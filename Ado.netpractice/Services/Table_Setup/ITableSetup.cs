using Ado.netpractice.Models;

namespace Ado.netpractice.Services.Table_Setup
{
    public interface ITableSetup
    {
        public string connstring();
        public List<TableNumber_Setup> Fetch_TableNumbers();

        public TableNumber_Setup AddTable(string tablename);

        public List<TableNumber_Setup> FetchingTable_ById(int Tableid);
    }
}
