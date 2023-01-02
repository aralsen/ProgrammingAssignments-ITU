using System;
using System.Data;
using System.Data.SqlClient;

namespace SuperMSoftware.SQLProcedures
{
    public class LoginProcedures
    {
        private SqlConnection sqlConnection = new SqlConnection("data source=innovatist;initial catalog=managementDB;integrated security=True;MultipleActiveResultSets=True;");

        public DataTable GetSellerUser(String userName, String userPassword)
        {
            SqlCommand command = new SqlCommand("sp_get_employee", sqlConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@email", userName);
            command.Parameters.AddWithValue("@password", userPassword);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();

            sqlConnection.Open();
            dataAdapter.Fill(dataTable);
            sqlConnection.Close();

            return dataTable;
        }

        public DataTable GetManagerUser(String userName, String userPassword)
        {
            SqlCommand command = new SqlCommand("sp_get_employee", sqlConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@email", userName);
            command.Parameters.AddWithValue("@password", userPassword);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();

            sqlConnection.Open();
            dataAdapter.Fill(dataTable);
            sqlConnection.Close();

            return dataTable;
        }
    }
}
