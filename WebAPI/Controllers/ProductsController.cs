using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class ProductsController : ApiController
    {
        private static readonly ProductRepository repository = new ProductRepository();
        // GET: api/Products
        public IEnumerable<ProductBL> Get()
        {
            return repository.GetALlProducts();
        }

        // GET: api/Products/5
        public ProductBL Get(int id)
        {
            return repository.GetProductByID(id);
        }

        // POST: api/Products
        public void Post([FromBody]ProductBL product)
        {
            repository.InsertProduct(product);
        }

        // PUT: api/Products/5
        public void Put(int id, [FromBody]double newPrice)
        {
            repository.UpdatePrice(id, newPrice);
        }

        // DELETE: api/Products/5
        public void Delete(int id)
        {
            repository.DeleteProduct(id);
        }
    }
}
