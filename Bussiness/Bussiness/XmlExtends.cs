using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace Bussiness
{
    public static class XmlExtends
    {
        public static string ToString(this XElement node, bool check)
        {
            StringBuilder stringBuilder = new StringBuilder();
            StringBuilder output = stringBuilder;
            XmlWriterSettings settings = new XmlWriterSettings()
            {
                CheckCharacters = check,
                OmitXmlDeclaration = true,
                Indent = true
            };
            using (XmlWriter writer = XmlWriter.Create(output, settings))
                node.WriteTo(writer);
            return ((object)stringBuilder).ToString();
        }
    }
}