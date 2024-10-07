using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechShop.Interfaces;
using TechShop.Modals;
using TechShop.util;

namespace TechShop.Services
{
    public class ProductService : IProductService
    {

        SqlConnection sqlConnection = null;
        SqlCommand cmd = null;
        string filepath = Config.DbConfigFilePath;
        public ProductService()
        {
            sqlConnection = DBConnection.GetConnection(filepath);
            cmd = new SqlCommand();
            cmd.Connection = sqlConnection;
        }

        public Product GetProductDetails(int productId)
        {
            Product product = null;

            try
            {
                cmd.CommandText = "SELECT * FROM Products WHERE ProductID = @ProductID";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ProductID", productId);

                if (sqlConnection.State == System.Data.ConnectionState.Closed)
                {
                    sqlConnection.Open();
                }

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    product = new Product
                    {
                        ProductID = (int)reader["ProductID"],
                        ProductName = (string)reader["ProductName"],
                        Price = (decimal)reader["Price"],
                        Description = (string)reader["Description"],
                        //StockQuantity = (int)reader["StockQuantity"]
                    };
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while retrieving product details: " + ex.Message);
            }
            finally
            {
                if (sqlConnection.State == System.Data.ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }

            return product;
        }

        public bool UpdateProductInfo(Product product)
        {
            bool isUpdated = false;

            try
            {
                cmd.CommandText = @"UPDATE Products 
                            SET ProductName = @ProductName, 
                                Price = @Price, 
                                Description = @Description,
                                StockQuantity = @StockQuantity
                            WHERE ProductID = @ProductID";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ProductID", product.ProductID);
                cmd.Parameters.AddWithValue("@ProductName", product.ProductName);
                cmd.Parameters.AddWithValue("@Price", product.Price);
                cmd.Parameters.AddWithValue("@Description", product.Description);
                //cmd.Parameters.AddWithValue("@StockQuantity", product.StockQuantity);

                if (sqlConnection.State == System.Data.ConnectionState.Closed)
                {
                    sqlConnection.Open();
                }

                int rowsAffected = cmd.ExecuteNonQuery();
                isUpdated = rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while updating product info: " + ex.Message);
            }
            finally
            {
                if (sqlConnection.State == System.Data.ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }

            return isUpdated;
        }

        public bool IsProductInStock(int productId)
        {
            bool inStock = false;

            try
            {
                cmd.CommandText = "SELECT StockQuantity FROM Products WHERE ProductID = @ProductID";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ProductID", productId);

                if (sqlConnection.State == System.Data.ConnectionState.Closed)
                {
                    sqlConnection.Open();
                }

                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    int stockQuantity = (int)result;
                    inStock = stockQuantity > 0;  // True if stock is greater than zero
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while checking product stock: " + ex.Message);
            }
            finally
            {
                if (sqlConnection.State == System.Data.ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }

            return inStock;
        }

    }
}
