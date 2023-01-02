using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using SuperMSoftware.Models;

namespace SuperMSoftware.SQLProcedures
{
    public class BillProcedures
    {
        private SqlConnection sqlConnection = new SqlConnection("data source=innovatist;initial catalog=managementDB;integrated security=True;MultipleActiveResultSets=True;");

        public bool AddBill(bills bill)
        {
            SqlCommand command = new SqlCommand("sp_add_bill", sqlConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@bill_id", bill.bill_id);
            command.Parameters.AddWithValue("@employee_id", bill.employee_id);
            command.Parameters.AddWithValue("@bill_date", bill.bill_date);
            command.Parameters.AddWithValue("@total_amount", bill.total_amount);

            sqlConnection.Open();
            int error = command.ExecuteNonQuery();
            sqlConnection.Close();

            if (error >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<bills> GetAllBills()
        {
            List<bills> bills = new List<bills>();
            SqlCommand command = new SqlCommand("sp_get_bills", sqlConnection);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();

            sqlConnection.Open();
            dataAdapter.Fill(dataTable);
            sqlConnection.Close();

            bills = (from DataRow dataRow in dataTable.Rows
                     select new bills()
                     {
                         bill_id = Convert.ToInt32(dataRow["bill_id"]),
                         employee_id = Convert.ToInt32(dataRow["employee_id"]),
                         bill_date = Convert.ToString(dataRow["bill_date"]),
                         total_amount = Convert.ToInt32(dataRow["total_amount"])
                     }).ToList();

            return bills;
        }

        public bool DeleteBill(int id)
        {
            SqlCommand command = new SqlCommand("sp_delete_bill", sqlConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@bill_id", id);

            sqlConnection.Open();
            int error = command.ExecuteNonQuery();
            sqlConnection.Close();

            if (error >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
