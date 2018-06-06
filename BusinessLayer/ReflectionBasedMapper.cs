using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class ReflectionBasedMapper<TS, TD>  : IMapper<TS, TD> where TS : new() where TD : new()
    {
        public TD Map(TS source)
        {
            TD destination = new TD();
            Type sourcetype = source.GetType();
            Type destinationtype = destination.GetType();
            var sourceProperties = sourcetype.GetProperties();
            foreach (var item in sourceProperties)
            {
                PropertyInfo prop = destinationtype.GetProperty(item.Name);
                if (prop != null)
                    prop.SetValue(destination, item.GetValue(source));
            }
            return destination;
        }

        public TS MapBack(TD source)
        {
            TS destination = new TS();
            Type sourcetype = source.GetType();
            Type destinationtype = destination.GetType();
            var sourceProperties = sourcetype.GetProperties();
            foreach (var item in sourceProperties)
            {
                PropertyInfo prop = destinationtype.GetProperty(item.Name);
                if (prop != null)
                    prop.SetValue(destination, item.GetValue(source));
            }
            return destination;
        }
    }
}
