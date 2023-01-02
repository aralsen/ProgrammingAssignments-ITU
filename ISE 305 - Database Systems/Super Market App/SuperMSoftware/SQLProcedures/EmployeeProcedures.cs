using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
using SuperMSoftware.Models;

namespace SuperMSoftware.SQLProcedures
{
    public class EmployeeProcedures
    {
        private SqlConnection sqlConnection = new SqlConnection("data source=innovatist;initial catalog=managementDB;integrated security=True;MultipleActiveResultSets=True;");

        public bool AddEmployee(employees employee)
        {
            SqlCommand command = new SqlCommand("sp_add_employee", sqlConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@employee_id", employee.employee_id);
            command.Parameters.AddWithValue("@email", employee.email);
            command.Parameters.AddWithValue("@name", employee.name);
            command.Parameters.AddWithValue("@phone", employee.phone);
            command.Parameters.AddWithValue("@age", employee.age);
            command.Parameters.AddWithValue("@job_id", employee.job_id);
            command.Parameters.AddWithValue("@password", employee.password);

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

        public List<employees> GetAllManagers()
        {
            List<employees> allManagers = new List<employees>();
            SqlCommand command = new SqlCommand("sp_display_managers", sqlConnection);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();

            sqlConnection.Open();
            dataAdapter.Fill(dataTable);
            sqlConnection.Close();

            allManagers = (from DataRow dataRow in dataTable.Rows
                        select new employees()
                        {
                            employee_id = Convert.ToInt32(dataRow["employee_id"]),
                            email = Convert.ToString(dataRow["email"]),
                            name = Convert.ToString(dataRow["name"]),
                            phone = Convert.ToString(dataRow["phone"]),
                            age = Convert.ToInt32(dataRow["age"]),
                            job_id = Convert.ToInt32(dataRow["job_id"]),
                            password = Convert.ToString(dataRow["password"])
                        }).ToList();

            return allManagers;
        }

        public List<employees> GetAllSalespersons()
        {
            List<employees> allSalesperson = new List<employees>();
            SqlCommand command = new SqlCommand("sp_display_salespersons", sqlConnection);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();

            sqlConnection.Open();
            dataAdapter.Fill(dataTable);
            sqlConnection.Close();

            allSalesperson = (from DataRow dataRow in dataTable.Rows
                select new employees()
                {
                    employee_id = Convert.ToInt32(dataRow["employee_id"]),
                    email = Convert.ToString(dataRow["email"]),
                    name = Convert.ToString(dataRow["name"]),
                    phone = Convert.ToString(dataRow["phone"]),
                    age = Convert.ToInt32(dataRow["age"]),
                    job_id = Convert.ToInt32(dataRow["job_id"]),
                    password = Convert.ToString(dataRow["password"])
                }).ToList();

            return allSalesperson;
        }

        public bool DeleteEmployee(int id)
        {
            SqlCommand command = new SqlCommand("sp_delete_employee", sqlConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@employee_id", id);

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

        public bool UpdateEmployee(employees employee)
        {
            SqlCommand command = new SqlCommand("sp_update_employee", sqlConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@employee_id", employee.employee_id);
            command.Parameters.AddWithValue("@email", employee.email);
            command.Parameters.AddWithValue("@name", employee.name);
            command.Parameters.AddWithValue("@phone", employee.phone);
            command.Parameters.AddWithValue("@age", employee.age);
            command.Parameters.AddWithValue("@job_id", employee.job_id);
            command.Parameters.AddWithValue("@password", employee.password);

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
        public DataTable GetEmployeeID(String text)
        {
            SqlCommand command = new SqlCommand("sp_get_employee_id", sqlConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@email", text);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();

            sqlConnection.Open();
            dataAdapter.Fill(dataTable);
            sqlConnection.Close();

            return dataTable;
        }

    }
}
