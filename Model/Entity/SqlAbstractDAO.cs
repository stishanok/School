using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Model.Entity
{
    public class SqlAbstractDAO:  IAbstractDAO
    {
        private string connectionString = "";
        
        public IDbConnection GetConnection()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }

        public void ReleaseConnection(IDbConnection connection)
        {
            connection.Close();
        }


    }
} 
