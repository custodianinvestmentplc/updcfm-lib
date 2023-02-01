using System.Data;
using System.Data.SqlClient;

namespace Custodian.Properties.Estates.Helpers.Services
{
    public static class Database
    {
        public static IDbConnection Connect(string connectionstring)
        {
            try
            {
                IDbConnection db = new SqlConnection(connectionstring);

                return db;
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Cannot Open Database: {ex.Message}");
            }
        }
    }
}
