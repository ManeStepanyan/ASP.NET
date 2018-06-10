using DataAccessLayer;
using System.Collections.Generic;

namespace BusinessLayer
{
    /// <summary>
    /// Business Layer to perform crud operations
    /// </summary>
    public class ProductRepository
    {
        /// <summary>
        /// instance of data access layer
        /// </summary>       
        private readonly DAL dal;

        /// <summary>
        /// Instance of mapper 
        /// </summary>
        private readonly ReflectionBasedMapper<ProductBL, ProductDAL> mapper;

        /// <summary>
        /// Creates Product Repository
        /// </summary>
        public ProductRepository()
        {
            this.dal = new DAL();
            this.mapper = new ReflectionBasedMapper<ProductBL, ProductDAL>();
        }

        /// <summary>
        /// Getting product by specified ID
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public ProductBL GetProductByID(int id)
        {
            return this.mapper.MapBack(this.dal.GetProductByID(id));
        }

        /// <summary>
        /// Getting all the products
        /// </summary>
        /// <returns></returns>
        public List<ProductBL> GetAll()
        {
            var list = new List<ProductBL>();
            var products = this.dal.GetAllProducts();

            foreach (var item in products)
            {
                list.Add(this.mapper.MapBack(item));
            }
            return list;
        }

        /// <summary>
        /// Add new product
        /// </summary>
        /// <param name="product"></param>
        public void InsertProduct(ProductBL product)
        {         
            this.dal.InsertProduct(this.mapper.Map(product));
        }

        /// <summary>
        /// Update a product
        /// </summary>
        /// <param name="id"></param>
        /// <param name="newName"></param>
        /// <param name="newPrice"></param>
        public void Update(int id, ProductBL product)
        {
            this.dal.UpdateProduct(id, product.Name, product.Price);
        }

        /// <summary>
        /// deleting a product
        /// </summary>
        /// <param name="id"></param>
        public void DeleteProduct(int id)
        {
            this.dal.DeleteProduct(id);
        }
    }
}
