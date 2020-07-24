using System.IO;
using System.Text;
using System.Xml.Linq;

namespace Domain.Serializers
{
    /// <summary>
    /// Class contains extension methods for Xml element handling
    /// </summary>
    public static class XElementSerializer
    {
        /// <summary>
        /// Method serializes a given @param object into an XElement
        /// </summary>
        /// <typeparam name="T">Object type</typeparam>
        /// <param name="obj">Object content</param>
        /// <returns></returns>
        public static XElement ToXElement<T>(this object obj)
        {
            using (var memoryStream = new MemoryStream())
            {
                using (TextWriter streamWriter = new StreamWriter(memoryStream))
                {
                    var xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
                    xmlSerializer.Serialize(streamWriter, obj);
                    return XElement.Parse(Encoding.ASCII.GetString(memoryStream.ToArray()));
                }
            }
        }

        /// <summary>
        /// Method deserializes a given XElement into a T object
        /// </summary>
        /// <typeparam name="T">Object type</typeparam>
        /// <param name="xElement">Xml content</param>
        /// <returns></returns>
        public static T FromXElement<T>(this XElement xElement)
        {
            var xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
            return (T)xmlSerializer.Deserialize(xElement.CreateReader());
        }

    }
}
