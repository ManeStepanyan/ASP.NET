// չմոռանաս մի հատ մեթոդ գրես
namespace BusinessLayer
{
    /// <summary>
    /// Mapping products for corresponding layers
    /// </summary>
    /// <typeparam name="TS"></typeparam>
    /// <typeparam name="TD"></typeparam>
    public class ReflectionBasedMapper<TS, TD> : IMapper<TS, TD> where TS : new() where TD : new()
    {
        /// <summary>
        /// mapping from source to destionation
        /// </summary>
        /// <param name="source">Source object</param>
        /// <returns></returns>
        public TD Map(TS source)
        {
            var destination = new TD();
            var sourcetype = source.GetType();
            var destinationtype = destination.GetType();
            var sourceProperties = sourcetype.GetProperties();

            foreach (var item in sourceProperties)
            {
                var prop = destinationtype.GetProperty(item.Name);
                if (prop != null)
                {
                    prop.SetValue(destination, item.GetValue(source));
                }
            }
            return destination;
        }

        /// <summary>
        /// mapping back
        /// </summary>
        /// <param name="source">Source object</param>
        /// <returns></returns>
        public TS MapBack(TD source)
        {
            var destination = new TS();
            var sourcetype = source.GetType();
            var destinationtype = destination.GetType();
            var sourceProperties = sourcetype.GetProperties();

            foreach (var item in sourceProperties)
            {
                var prop = destinationtype.GetProperty(item.Name);
                if (prop != null)
                {
                    prop.SetValue(destination, item.GetValue(source));
                }
            }
            return destination;
        }
    }
}
