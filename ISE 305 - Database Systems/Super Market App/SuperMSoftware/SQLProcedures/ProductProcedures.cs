using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using SuperMSoftware.Models;

namespace SuperMSoftware.SQLProcedures
{
    public class ProductProcedures
    {
        private SqlConnection sqlConnection = new SqlConnection("data source=innovatist;initial catalog=managementDB;integrated security=True;MultipleActiveResultSets=True;");

        public bool AddProduct(products product)
        {
            SqlCommand command = new SqlCommand("sp_add_product", sqlConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@product_id", product.product_id);
            command.Parameters.AddWithValue("@product_name", product.product_name);
            command.Parameters.AddWithValue("@stock", product.stock);
            command.Parameters.AddWithValue("@price", product.price);
            command.Parameters.AddWithValue("@category_id", product.category_id);

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

        public DataTable GetCategoryID(String text)
        {
            SqlCommand command = new SqlCommand("sp_get_category_id", sqlConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@category_name", text);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();

            sqlConnection.Open();
            dataAdapter.Fill(dataTable);
            sqlConnection.Close();

            return dataTable;
        }

        public List<products> GetAllProducts()
        {
            List<products> products = new List<products>();
            SqlCommand command = new SqlCommand("sp_display_products", sqlConnection);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();

            sqlConnection.Open();
            dataAdapter.Fill(dataTable);
            sqlConnection.Close();

            products = (from DataRow dataRow in dataTable.Rows
                          select new products()
                          {
                              product_id = Convert.ToInt32(dataRow["product_id"]),
                              product_name = Convert.ToString(dataRow["product_name"]),
                              stock = Convert.ToInt32(dataRow["stock"]),
                              price = Convert.ToInt32(dataRow["price"]),
                              category_id = Convert.ToInt32(dataRow["category_id"])
                          }).ToList();

            return products;
        }

        public bool DeleteProduct(int id)
        {
            SqlCommand command = new SqlCommand("sp_delete_product", sqlConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@product_id", id);

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

        public bool UpdateProduct(products product)
        {
            SqlCommand command = new SqlCommand("sp_update_product", sqlConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@product_id", product.product_id);
            command.Parameters.AddWithValue("@product_name", product.product_name);
            command.Parameters.AddWithValue("@stock", product.stock);
            command.Parameters.AddWithValue("@price", product.price);
            command.Parameters.AddWithValue("@category_id", product.category_id);

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

        public List<String> GetProductNames()
        {
            List<String> productNames = new List<String>();
            SqlCommand command = new SqlCommand("sp_get_product_names", sqlConnection);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();

            sqlConnection.Open();
            dataAdapter.Fill(dataTable);
            sqlConnection.Close();

            productNames = (from DataRow dataRow in dataTable.Rows
                             select dataRow["product_name"].ToString()).ToList();

            return productNames;
        }

        public List<products> GetProductsByCategory(String category)
        {
            List<products> products = new List<products>();
            SqlCommand command = new SqlCommand("sp_get_products_by_category", sqlConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@category_name", category);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();

            sqlConnection.Open();
            dataAdapter.Fill(dataTable);
            sqlConnection.Close();

            products = (from DataRow dataRow in dataTable.Rows
                        select new products()
                        {
                            product_id = Convert.ToInt32(dataRow["product_id"]),
                            product_name = Convert.ToString(dataRow["product_name"]),
                            stock = Convert.ToInt32(dataRow["stock"]),
                            price = Convert.ToInt32(dataRow["price"]),
                            category_id = Convert.ToInt32(dataRow["category_id"])
                        }).ToList();

            return products;
        }

        public DataTable GetProductNamePriceQuantity()
        {
            SqlCommand command = new SqlCommand("sp_get_product_namepricequantity", sqlConnection);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();

            sqlConnection.Open();
            dataAdapter.Fill(dataTable);
            sqlConnection.Close();

            return dataTable;
        }

        public DataTable GetProductNamePriceQuantityByCategory(String category)
        {
            SqlCommand command = new SqlCommand("sp_get_product_namepricequantity_by_category", sqlConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@category_name", category);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();

            sqlConnection.Open();
            dataAdapter.Fill(dataTable);
            sqlConnection.Close();

            return dataTable;
        }
    }
}
