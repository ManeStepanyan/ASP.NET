using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class ProductRepository
    {
        private readonly DAL dal;
        public ProductRepository()
        {
            dal = new DAL();
        }
        private ProductDAL ConvertFromBL(ProductBL productBL)
        {
            ProductDAL productDAL = new ProductDAL()
            {
                ID = productBL.ID,
                Name = productBL.Name,
                Price = productBL.Price,
                Category = "null"
            };
            return productDAL;
        }
        private ProductBL ConvertFromDAL(ProductDAL productDAL)
        {
            ProductBL productBL = new ProductBL()
            {
                ID = productDAL.ID,
                Name = productDAL.Name,
                Price = productDAL.Price,
            };
            return productBL;
        }
        public ProductBL GetProductByID(int ID)
        {
            return ConvertFromDAL(dal.GetProductByID(ID));
        }
        public List<ProductBL> GetALlProducts()
        {
            List<ProductBL> list = new List<ProductBL>();
            var products = dal.GetAllProducts();
            foreach (var item in products)
            {
                var temp = item;
                list.Add(ConvertFromDAL(temp));
            }
            return list;
        }
        public void InsertProduct(ProductBL product)
        {
            dal.InsertProduct(ConvertFromBL(product));
        }
        public void UpdatePrice(int ID, double newPrice)
        {
            dal.UpdatePrice(ID, newPrice);
        }
        public void DeleteProduct(int ID)
        {
            dal.DeleteProduct(ID);
        }
    }
}
