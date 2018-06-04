using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DAL
    {
        private readonly string connectionString;
        public DAL()
        {
            this.connectionString = System.Configuration.ConfigurationManager.
            ConnectionStrings["NameOfMyStringConnection"].ConnectionString;
        }
        public ProductDAL GetProductByID(int ID)
        {
            ProductDAL product = new ProductDAL();
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = this.connectionString;
                connection.Open();
                SqlCommand cmd = new SqlCommand("select * from Product where ID=@ID", connection);
                cmd.Parameters.AddWithValue("@ID", ID);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    product.ID = (int)reader["ID"];
                    product.Name = (string)reader["Name"];
                    product.Price = (double)reader["Price"];
                    product.Category = (string)reader["Category"];
                }
                return product;
            }
        }
        public List<ProductDAL> GetAllProducts()
        {
            List<ProductDAL> products = new List<ProductDAL>();
            ProductDAL product;
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = this.connectionString;
                connection.Open();
                SqlCommand cmd = new SqlCommand("select * from Product ", connection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    product = new ProductDAL();
                    product.ID = (int)reader["ID"];
                    product.Name = (string)reader["Name"];
                    product.Price = (double)reader["Price"];
                    product.Category = (string)reader["Category"];
                    products.Add(product);
                }
            }
            return products;
        }
        public void InsertProduct(ProductDAL product)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = this.connectionString;
                connection.Open();
                // prepare command string
                string insertString = @"
                 insert into Product
                (Name,Price,Category)
                values (@Name,@Price,@Category)";
                // 1. Instantiate a new command with a query and connection
                SqlCommand cmd = new SqlCommand(insertString, connection);
                cmd.Parameters.AddWithValue("@Name", product.Name);
                cmd.Parameters.AddWithValue("@Price", product.Price);
                cmd.Parameters.AddWithValue("@Category", product.Category);
                // 2. Call ExecuteNonQuery to send command
                cmd.ExecuteNonQuery();
            }
        }
        public void UpdatePrice(int ID, double newPrice)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = this.connectionString;
                connection.Open();
                // prepare command string
                string updateString = @"
                 update Product
                 set Price = @newPrice
                 where ID=@ID";
                // 1. Instantiate a new command with command text only
                SqlCommand cmd = new SqlCommand(updateString, connection);
                cmd.Parameters.AddWithValue("@newPrice", newPrice);
                cmd.Parameters.AddWithValue("@ID", ID);
                cmd.ExecuteNonQuery();
            }
        }
        public void DeleteProduct(int ID)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = this.connectionString;
                connection.Open();
                // prepare command string
                string deleteString = @"
                delete from Product
                where ID=@ID";
                // 1. Instantiate a new command
                SqlCommand cmd = new SqlCommand(deleteString,connection);
                cmd.Parameters.AddWithValue("@ID", ID);
                // 2. Call ExecuteNonQuery to send command
                cmd.ExecuteNonQuery();
            }
        }
    }
}