using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{/// <summary>
/// Business Layer to perform crud operations
/// </summary>
    public class ProductRepository
    {
        private readonly DAL dal; // instance of data access layer
        public ProductRepository()
        {
            dal = new DAL();
        }
        /// <summary>
        /// Getting product by specified ID
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public ProductBL GetProductByID(int ID)
        {
            ReflectionBasedMapper<ProductBL, ProductDAL> mapper = new ReflectionBasedMapper<ProductBL, ProductDAL>();
            return mapper.MapBack(dal.GetProductByID(ID));
        }
        /// <summary>
        /// Getting all the products
        /// </summary>
        /// <returns></returns>
        public List<ProductBL> GetALlProducts()
        {
            ReflectionBasedMapper<ProductBL, ProductDAL> mapper = new ReflectionBasedMapper<ProductBL, ProductDAL>();
            List<ProductBL> list = new List<ProductBL>();
            var products = dal.GetAllProducts();
            foreach (var item in products)
            {
                var temp = item;
                list.Add(mapper.MapBack(temp));
            }
            return list;
        }
        /// <summary>
        /// Add new product
        /// </summary>
        /// <param name="product"></param>
        public void InsertProduct(ProductBL product)
        {
            ReflectionBasedMapper<ProductBL, ProductDAL> mapper = new ReflectionBasedMapper<ProductBL, ProductDAL>();
            dal.InsertProduct(mapper.Map(product));
        }
        /// <summary>
        /// Update a product
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="newName"></param>
        /// <param name="newPrice"></param>
        public void Update(int ID,string newName, double newPrice)
        {
            dal.UpdateProduct(ID, newName, newPrice);
        }
        /// <summary>
        /// deleting a product
        /// </summary>
        /// <param name="ID"></param>
        public void DeleteProduct(int ID)
        {
            dal.DeleteProduct(ID);
        }
    }
}
