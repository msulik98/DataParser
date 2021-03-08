using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataParser
{
    public class XMLParser : IDataParser
    {
        public XMLParser()
        {
        }
        public bool CanIParse(string extension) => extension == "xml";
        public ICollection<User> ParseFile(string path)
        {
            Console.WriteLine("XML has been parsed! :)))");
            return null;
        }
    }
}
