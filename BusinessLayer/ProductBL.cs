using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace BusinessLayer
{
    /// <summary>
    /// Class to map DAl's Product
    /// </summary>
    [DataContract]
    public class ProductBL
    {[DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public double Price { get; set; }
    }
    // "http://schemas.datacontract.org/2004/07/BusinessLayer"
  
    [XmlRoot(Namespace = "http://schemas.datacontract.org/2004/07/BusinessLayer")]
    [DataContract]
    public class ArrayOfProductBL
    { [DataMember]
        [XmlElement("ProductBL")]
        public ProductBL[] collection { get; set; }
    }
}
