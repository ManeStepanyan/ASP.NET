using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;

namespace DataAccessLayer
{
    /// <summary>
    /// Class to connect to the database and to do crud operation
    /// </summary>
    public class DAL
    { 
        /// <summary>
        /// Connection string
        /// </summary>
        private readonly string connectionString;

        /// <summary>
        /// Instantiate our connection string reading it from web.config
        /// </summary>
        public DAL()
        {
            this.connectionString = ConfigurationManager.ConnectionStrings["NameOfMyStringConnection"].ConnectionString;
        }

        /// <summary>
        /// Getting product by ID
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public ProductDAL GetProductByID(int ID)
        {
            var product = new ProductDAL();
            using (var connection = new SqlConnection())
            {
                connection.ConnectionString = this.connectionString;
                connection.Open();
                var cmd = new SqlCommand("select * from Product where ID=@ID", connection);
                cmd.Parameters.AddWithValue("@ID", ID);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        product.ID = (int)reader["ID"];
                        product.Name = (string)reader["Name"];
                        product.Price = (double)reader["Price"];
                        product.Category = (string)reader["Category"];
                    }
                }
                return product;
            }
        }

        /// <summary>
        /// Getting all products
        /// </summary>
        /// <returns></returns>
        public List<ProductDAL> GetAllProducts()
        {
            var products = new List<ProductDAL>();
            ProductDAL product;
            using (var connection = new SqlConnection())
            {
                connection.ConnectionString = this.connectionString;
                connection.Open();
                var cmd = new SqlCommand("select * from Product ", connection);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        product = new ProductDAL
                        {
                            ID = (int)reader["ID"],
                            Name = (string)reader["Name"],
                            Price = (double)reader["Price"],
                            Category = (string)reader["Category"]
                        };
                        products.Add(product);
                    }
                }
            }
            return products;
        }

        /// <summary>
        /// Inserting product
        /// </summary>
        /// <param name="product">Some product instance </param>
        public void InsertProduct(ProductDAL product)
        {
            using (var connection = new SqlConnection())
            {
                connection.ConnectionString = this.connectionString;
                connection.Open();
                // prepare command string
                var insertString = @"
                 insert into Product
                (Name,Price,Category)
                values (@Name,@Price,@Category)";

                // 1. Instantiate a new command with a query and connection
                var cmd = new SqlCommand(insertString, connection);
                cmd.Parameters.AddWithValue("@Name", product.Name);
                cmd.Parameters.AddWithValue("@Price", product.Price);
                cmd.Parameters.AddWithValue("@Category", product.Category);

                // 2. Call ExecuteNonQuery to send command
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Updating Product
        /// </summary>
        /// <param name="ID">ID of product</param>
        /// <param name="newName">New name of product</param>
        /// <param name="newPrice">New price of product</param>
        public void UpdateProduct(int ID, string newName, double newPrice)
        {
            using (var connection = new SqlConnection())
            {
                connection.ConnectionString = this.connectionString;
                connection.Open();

                // prepare command string
                var updateString = @"
                 update Product
                 set Price = @newPrice,
                 Name=@newName
                 where ID=@ID";

                // 1. Instantiate a new command with command text only
                var cmd = new SqlCommand(updateString, connection);
                cmd.Parameters.AddWithValue("@newPrice", newPrice);
                cmd.Parameters.AddWithValue("@ID", ID);
                cmd.Parameters.AddWithValue("@newName", newName);
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Deleting product
        /// </summary>
        /// <param name="ID">Product's ID</param>
        public void DeleteProduct(int ID)
        {
            using (var connection = new SqlConnection())
            {
                connection.ConnectionString = this.connectionString;
                connection.Open();

                // prepare command string
                var deleteString = @"
                delete from Product
                where ID=@ID";

                // 1. Instantiate a new command
                var cmd = new SqlCommand(deleteString, connection);
                cmd.Parameters.AddWithValue("@ID", ID);

                // 2. Call ExecuteNonQuery to send command
                cmd.ExecuteNonQuery();
            }
        }
    }
}