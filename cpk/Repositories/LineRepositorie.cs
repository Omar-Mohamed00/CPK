﻿using Microsoft.Data.SqlClient;
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

            return lines1003ForGraph.OrderBy(l => l.CpkLin3We3Timestamp).ToList();
        }
        public (float? avgValue, float? lastValue) GetLine1003DetailsFromDb()
        {
            var query = @"
       SELECT 
    (SELECT AVG(cpk_lin3_we3_VALUE) 
     FROM (SELECT TOP 40 cpk_lin3_we3_VALUE 
           FROM Line1003 
           ORDER BY cpk_lin3_we3_TIMESTAMP DESC) AS Last40Rows) AS AvgValue,
    (SELECT TOP 1 cpk_lin3_we3_VALUE 
     FROM Line1003 
     ORDER BY cpk_lin3_we3_TIMESTAMP DESC) AS LastValue;

    ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                float? avgValue = reader["AvgValue"] != DBNull.Value ? (float?)Convert.ToDouble(reader["AvgValue"]) : null;
                                float? lastValue = reader["LastValue"] != DBNull.Value ? (float?)Convert.ToDouble(reader["LastValue"]) : null;

                                return (avgValue, lastValue);
                            }
                        }
                    }
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

            return (null, null);
        }
        private DataTable GetLine1003ForGraphFromDb()
        {

            var query = "SELECT TOP 40 cpk_lin3_we3_VALUE, cpk_lin3_we3_Timestamp FROM Line1003 ORDER BY cpk_lin3_we3_Timestamp Desc;\r\n";
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

            return lines1010ForGraph.OrderBy(l => l.CpkLin10We10Timestamp).ToList();

        }
        private DataTable GetLine1010ForGraphFromDb()
        {

            var query = "SELECT TOP 40 cpk_lin10_we10_VALUE, cpk_lin10_we10_Timestamp FROM Line1010 ORDER BY cpk_lin10_we10_Timestamp Desc;\r\n";
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
        public (float? avgValue, float? lastValue) GetLine1010DetailsFromDb()
        {
            var query = @"
     SELECT 
    (SELECT AVG(cpk_lin10_we10_VALUE) 
     FROM (SELECT TOP 40 cpk_lin10_we10_VALUE 
           FROM Line1010 
           ORDER BY cpk_lin10_we10_TIMESTAMP DESC) AS Last40Rows) AS AvgValue,
    (SELECT TOP 1 cpk_lin10_we10_VALUE 
     FROM Line1010 
     ORDER BY cpk_lin10_we10_TIMESTAMP DESC) AS LastValue;

    ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                float? avgValue = reader["AvgValue"] != DBNull.Value ? (float?)Convert.ToDouble(reader["AvgValue"]) : null;
                                float? lastValue = reader["LastValue"] != DBNull.Value ? (float?)Convert.ToDouble(reader["LastValue"]) : null;

                                return (avgValue, lastValue);
                            }
                        }
                    }
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

            return (null, null);
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
            return lines1011ForGraph.OrderBy(l => l.CpkLin11We11Timestamp).ToList();

        }
        private DataTable GetLine1011ForGraphFromDb()
        {

            var query = "SELECT TOP 40 cpk_lin11_we11_VALUE, cpk_lin11_we11_Timestamp FROM Line1011 ORDER BY cpk_lin11_we11_Timestamp Desc;\r\n";
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
        public (float? avgValue, float? lastValue) GetLine1011DetailsFromDb()
        {
            var query = @"
       SELECT 
    (SELECT AVG(cpk_lin11_we11_VALUE) 
     FROM (SELECT TOP 40 cpk_lin11_we11_VALUE 
           FROM Line1011 
           ORDER BY cpk_lin11_we11_TIMESTAMP DESC) AS Last40Rows) AS AvgValue,
    (SELECT TOP 1 cpk_lin11_we11_VALUE 
     FROM Line1011 
     ORDER BY cpk_lin11_we11_TIMESTAMP DESC) AS LastValue;

    ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                float? avgValue = reader["AvgValue"] != DBNull.Value ? (float?)Convert.ToDouble(reader["AvgValue"]) : null;
                                float? lastValue = reader["LastValue"] != DBNull.Value ? (float?)Convert.ToDouble(reader["LastValue"]) : null;

                                return (avgValue, lastValue);
                            }
                        }
                    }
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

            return (null, null);
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
            return lines10113ForGraph.OrderBy(l => l.CpkLin3We3Timestamp).ToList();

        }
        public DataTable GetLine10113ForGraphFromDb()
        {

            var query = "SELECT TOP 40 cpk_lin3_we3_VALUE, cpk_lin3_we3_TIMESTAMP FROM Line10113 ORDER BY cpk_lin3_we3_TIMESTAMP Desc;\r\n";
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
        public (float? avgValue, float? lastValue) GetLine10113DetailsFromDb()
        {
            var query = @"
        SELECT 
    (SELECT AVG(cpk_lin3_we3_VALUE) 
     FROM (SELECT TOP 40 cpk_lin3_we3_VALUE 
           FROM Line10113 
           ORDER BY cpk_lin3_we3_TIMESTAMP DESC) AS Last40Rows) AS AvgValue,
    (SELECT TOP 1 cpk_lin3_we3_VALUE 
     FROM Line10113 
     ORDER BY cpk_lin3_we3_TIMESTAMP DESC) AS LastValue;

    ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                float? avgValue = reader["AvgValue"] != DBNull.Value ? (float?)Convert.ToDouble(reader["AvgValue"]) : null;
                                float? lastValue = reader["LastValue"] != DBNull.Value ? (float?)Convert.ToDouble(reader["LastValue"]) : null;

                                return (avgValue, lastValue);
                            }
                        }
                    }
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

            return (null, null);
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
            return lines1013ForGraph.OrderBy(l => l.CpkLine13Wei13Timestamp).ToList();

        }
        public DataTable GetLine1013ForGraphFromDb()
        {

            var query = "SELECT TOP 40 cpk_line_13_wei13_VALUE, cpk_line_13_wei13_TIMESTAMP FROM Line1013 ORDER BY cpk_line_13_wei13_TIMESTAMP Desc;";
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
        public (float? avgValue, float? lastValue) GetLine1013DetailsFromDb()
        {
            var query = @"
    SELECT 
    (SELECT AVG(cpk_line_13_wei13_VALUE) 
     FROM (SELECT TOP 40 cpk_line_13_wei13_VALUE 
           FROM Line1013 
           ORDER BY cpk_line_13_wei13_TIMESTAMP DESC) AS Last40Rows) AS AvgValue,
    (SELECT TOP 1 cpk_line_13_wei13_VALUE 
     FROM Line1013 
     ORDER BY cpk_line_13_wei13_TIMESTAMP DESC) AS LastValue;

    ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                float? avgValue = reader["AvgValue"] != DBNull.Value ? (float?)Convert.ToDouble(reader["AvgValue"]) : null;
                                float? lastValue = reader["LastValue"] != DBNull.Value ? (float?)Convert.ToDouble(reader["LastValue"]) : null;

                                return (avgValue, lastValue);
                            }
                        }
                    }
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

            return (null, null);
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
                    CpkLine14We14Value = row["cpk_lin14_we14_VALUE"] != DBNull.Value ? Convert.ToSingle(row["cpk_lin14_we14_VALUE"]) : (float?)null,
                    CpkLine14We14Timestamp = row["cpk_lin14_we14_TIMESTAMP"] != DBNull.Value ? Convert.ToDateTime(row["cpk_lin14_we14_TIMESTAMP"]) : (DateTime?)null
                };
                lines1014ForGraph.Add(line1014ForGraph);
            }
            return lines1014ForGraph.OrderBy(l => l.CpkLine14We14Timestamp).ToList();

        }
        public DataTable GetLine1014ForGraphFromDb()
        {

            var query = "SELECT TOP 40 cpk_lin14_we14_VALUE, cpk_lin14_we14_TIMESTAMP FROM Line1014 ORDER BY cpk_lin14_we14_TIMESTAMP Desc;";
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
        public (float? avgValue, float? lastValue) GetLine1014DetailsFromDb()
        {
            var query = @"
      SELECT 
    (SELECT AVG(cpk_lin14_we14_VALUE) 
     FROM (SELECT TOP 40 cpk_lin14_we14_VALUE 
           FROM Line1014 
           ORDER BY cpk_lin14_we14_TIMESTAMP DESC) AS Last40Rows) AS AvgValue,
    (SELECT TOP 1 cpk_lin14_we14_VALUE 
     FROM Line1014 
     ORDER BY cpk_lin14_we14_TIMESTAMP DESC) AS LastValue;
    ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                float? avgValue = reader["AvgValue"] != DBNull.Value ? (float?)Convert.ToDouble(reader["AvgValue"]) : null;
                                float? lastValue = reader["LastValue"] != DBNull.Value ? (float?)Convert.ToDouble(reader["LastValue"]) : null;

                                return (avgValue, lastValue);
                            }
                        }
                    }
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

            return (null, null);
        }
    }
}
