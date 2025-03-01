using Microsoft.Data.SqlClient;
using Models;
using System.Data;

namespace cpk.Repositories
{
    public class LineRepositorie
    {
        string connectionString;

        public LineRepositorie(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public List<Line1003> GetLine1003ForGraph()
        {
            List<Line1003> lines1003ForGraph = new List<Line1003>();
            Line1003 line1003ForGraph;

            var data = GetLine1003ForGraphFromDb();

            foreach (DataRow row in data.Rows)
            {
                line1003ForGraph = new Line1003
                {
                    CpkLin3We3Value = row["cpk_lin3_we3_VALUE"] != DBNull.Value ? Convert.ToSingle(row["cpk_lin3_we3_VALUE"]) : (float?)null,
                    CpkLin3We3Timestamp = row["cpk_lin3_we3_Timestamp"] != DBNull.Value ? Convert.ToDateTime(row["cpk_lin3_we3_Timestamp"]) : (DateTime?)null
                };
                lines1003ForGraph.Add(line1003ForGraph);
            }

            return lines1003ForGraph;
        }
        private DataTable GetLine1003ForGraphFromDb()
        {

            var query = "SELECT TOP 30 cpk_lin3_we3_VALUE, cpk_lin3_we3_Timestamp FROM Line1003 ORDER BY cpk_lin3_we3_Timestamp DESC;\r\n";
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            dataTable.Load(reader);
                        }
                    }

                    return dataTable;
                }
                catch (Exception ex)
                {
                    throw;
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}
