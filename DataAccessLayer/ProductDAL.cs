using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{   
    /// <summary>
    /// class which corresponds to the product table from Database
    /// </summary>
    public class ProductDAL
    {    
        /// <summary>
        /// ID
        /// </summary>
        public int ID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

    }
}
