using BusinessLayer;
using System.Collections.Generic;
using System.Web.Http;

namespace WebAPI.Controllers
{
    /// <summary>
    /// Products controller
    /// </summary>
    public class ProductsController : ApiController
    {
        /// <summary>
        /// Instance of repository
        /// </summary>
        private readonly ProductRepository repository;

        /// <summary>
        /// Controller creation
        /// </summary>
        public ProductsController()
        {
            this.repository = new ProductRepository();
        }

        // GET: api/Products
        public IEnumerable<ProductBL> Get()
        {
            return this.repository.GetAll();
        }

        // GET: api/Products/5
        public ProductBL Get(int id)
        {
            return this.repository.GetProductByID(id);
        }

        // POST: api/Products
        public void Post([FromBody]ProductBL product)
        {
            this.repository.InsertProduct(product);
        }

        // PUT: api/Products/5
        public void Put(int id, [FromBody] ProductBL product)
        {
            this.repository.Update(id, product);
        }

        // DELETE: api/Products/5
        public void Delete(int id)
        {
            this.repository.DeleteProduct(id);
        }
    }
}
