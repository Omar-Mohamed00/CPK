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
        // Line1003
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
        // Line1010
        public List<Line1010> GetLine1010ForGraph()
        {
            List<Line1010> lines1010ForGraph = new List<Line1010>();
            Line1010 line1010ForGraph;

            var data = GetLine1010ForGraphFromDb();

            foreach (DataRow row in data.Rows)
            {
                line1010ForGraph = new Line1010
                {
                    CpkLin10We10Value = row["cpk_lin10_we10_VALUE"] != DBNull.Value ? Convert.ToSingle(row["cpk_lin10_we10_VALUE"]) : (float?)null,
                    CpkLin10We10Timestamp = row["cpk_lin10_we10_Timestamp"] != DBNull.Value ? Convert.ToDateTime(row["cpk_lin10_we10_Timestamp"]) : (DateTime?)null
                };
                lines1010ForGraph.Add(line1010ForGraph);
            }

            return lines1010ForGraph;
        }
        private DataTable GetLine1010ForGraphFromDb()
        {

            var query = "SELECT TOP 30 cpk_lin10_we10_VALUE, cpk_lin10_we10_Timestamp FROM Line1010 ORDER BY cpk_lin10_we10_Timestamp DESC;\r\n";
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
        // Line1011
        public List<Line1011> GetLine1011ForGraph()
        {
            List<Line1011> lines1011ForGraph = new List<Line1011>();
            Line1011 line1011ForGraph;

            var data = GetLine1011ForGraphFromDb();

            foreach (DataRow row in data.Rows)
            {
                line1011ForGraph = new Line1011
                {
                    CpkLin11We11Value = row["cpk_lin11_we11_VALUE"] != DBNull.Value ? Convert.ToSingle(row["cpk_lin11_we11_VALUE"]) : (float?)null,
                    CpkLin11We11Timestamp = row["cpk_lin11_we11_Timestamp"] != DBNull.Value ? Convert.ToDateTime(row["cpk_lin11_we11_Timestamp"]) : (DateTime?)null
                };
                lines1011ForGraph.Add(line1011ForGraph);
            }

            return lines1011ForGraph;
        }
        private DataTable GetLine1011ForGraphFromDb()
        {

            var query = "SELECT TOP 30 cpk_lin11_we11_VALUE, cpk_lin11_we11_Timestamp FROM Line1011 ORDER BY cpk_lin11_we11_Timestamp DESC;\r\n";
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
        // Line10113
        public List<Line10113> GetLine10113ForGraph()
        {
            List<Line10113> lines10113ForGraph = new List<Line10113>();
            Line10113 line10113ForGraph;

            var data = GetLine10113ForGraphFromDb();

            foreach (DataRow row in data.Rows)
            {
                line10113ForGraph = new Line10113
                {
                    CpkLin3We3Value = row["cpk_lin3_we3_VALUE"] != DBNull.Value ? Convert.ToSingle(row["cpk_lin3_we3_VALUE"]) : (float?)null,
                    CpkLin3We3Timestamp = row["cpk_lin3_we3_TIMESTAMP"] != DBNull.Value ? Convert.ToDateTime(row["cpk_lin3_we3_TIMESTAMP"]) : (DateTime?)null
                };
                lines10113ForGraph.Add(line10113ForGraph);
            }

            return lines10113ForGraph;
        }
        public DataTable GetLine10113ForGraphFromDb()
        {

            var query = "SELECT TOP 30 cpk_lin3_we3_VALUE, cpk_lin3_we3_TIMESTAMP FROM Line10113 ORDER BY cpk_lin3_we3_TIMESTAMP DESC;\r\n";
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
        // Line1013
        public List<Line1013> GetLine1013ForGraph()
        {
            List<Line1013> lines1013ForGraph = new List<Line1013>();
            Line1013 line1013ForGraph;

            var data = GetLine1013ForGraphFromDb();

            foreach (DataRow row in data.Rows)
            {
                line1013ForGraph = new Line1013
                {
                    CpkLine13Wei13Value = row["cpk_line_13_wei13_VALUE"] != DBNull.Value ? Convert.ToSingle(row["cpk_line_13_wei13_VALUE"]) : (float?)null,
                    CpkLine13Wei13Timestamp = row["cpk_line_13_wei13_TIMESTAMP"] != DBNull.Value ? Convert.ToDateTime(row["cpk_line_13_wei13_TIMESTAMP"]) : (DateTime?)null
                };
                lines1013ForGraph.Add(line1013ForGraph);
            }

            return lines1013ForGraph;
        }
        public DataTable GetLine1013ForGraphFromDb()
        {

            var query = "SELECT TOP 30 cpk_line_13_wei13_VALUE, cpk_line_13_wei13_TIMESTAMP FROM Line1013 ORDER BY cpk_line_13_wei13_TIMESTAMP DESC;";
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
        // Line1014
        public List<Line1014> GetLine1014ForGraph()
        {
            List<Line1014> lines1014ForGraph = new List<Line1014>();
            Line1014 line1014ForGraph;

            var data = GetLine1014ForGraphFromDb();

            foreach (DataRow row in data.Rows)
            {
                line1014ForGraph = new Line1014
                {
                    CpkLine14We14Value = row["cpk_line_14_we14_VALUE"] != DBNull.Value ? Convert.ToSingle(row["cpk_line_14_we14_VALUE"]) : (float?)null,
                    CpkLine14We14Timestamp = row["cpk_line_14_we14_TIMESTAMP"] != DBNull.Value ? Convert.ToDateTime(row["cpk_line_14_we14_TIMESTAMP"]) : (DateTime?)null
                };
                lines1014ForGraph.Add(line1014ForGraph);
            }

            return lines1014ForGraph;
        }
        public DataTable GetLine1014ForGraphFromDb()
        {

            var query = "SELECT TOP 30 cpk_line_14_we14_VALUE, cpk_line_14_we14_TIMESTAMP FROM Line1014 ORDER BY cpk_line_14_we14_TIMESTAMP DESC;";
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
