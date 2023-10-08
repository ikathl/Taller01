using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Xml.Linq;

namespace JazaniTaller.Infraestructure.Cores.Converters
{
    public class XMLToString : ValueConverter<XDocument, string>
    {
        public XMLToString() : base
            (                
                v => v.ToString(), 
                v => XDocument.Parse(v)
            )
        {

        }
    }
}