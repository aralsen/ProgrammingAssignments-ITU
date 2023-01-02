using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using SuperMSoftware.Models;

namespace SuperMSoftware.SQLProcedures
{
    public class CategoryProcedures
    {
        private SqlConnection sqlConnection = new SqlConnection("data source=innovatist;initial catalog=managementDB;integrated security=True;MultipleActiveResultSets=True;");

        public bool AddCategory(categories category)
        {
            SqlCommand command = new SqlCommand("sp_add_category", sqlConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@category_id", category.category_id);
            command.Parameters.AddWithValue("@category_name", category.category_name);
            command.Parameters.AddWithValue("@description", category.description);

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

        public List<categories> GetAllCategories()
        {
            List<categories> categories = new List<categories>();
            SqlCommand command = new SqlCommand("sp_display_categories", sqlConnection);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();

            sqlConnection.Open();
            dataAdapter.Fill(dataTable);
            sqlConnection.Close();

            categories = (from DataRow dataRow in dataTable.Rows
                          select new categories()
                          {
                              category_id = Convert.ToInt32(dataRow["category_id"]),
                              category_name = Convert.ToString(dataRow["category_name"]),
                              description = Convert.ToString(dataRow["description"])
                          }).ToList();

            return categories;
        }

        public bool DeleteCategory(int id)
        {
            SqlCommand command = new SqlCommand("sp_delete_category", sqlConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@category_id", id);

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

        public bool UpdateCategory(categories category)
        {
            SqlCommand command = new SqlCommand("sp_update_category", sqlConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@category_id", category.category_id);
            command.Parameters.AddWithValue("@category_name", category.category_name);
            command.Parameters.AddWithValue("@description", category.description);

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

        public List<String> GetCategoryNames()
        {
            List<String> categoryNames = new List<String>();
            SqlCommand command = new SqlCommand("sp_get_category_names", sqlConnection);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();

            sqlConnection.Open();
            dataAdapter.Fill(dataTable);
            sqlConnection.Close();

            categoryNames = (from DataRow dataRow in dataTable.Rows
                             select dataRow["category_name"].ToString()).ToList();

            return categoryNames;
        }
    }
}
