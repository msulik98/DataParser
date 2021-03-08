using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataParser
{
    public class CSVParser : IDataParser
    {
        public CSVParser()
        {
        }
        public bool CanIParse(string extension) => extension == "csv";
        public ICollection<User> ParseFile(string path)
        {
            Console.WriteLine("CSV has been parsed! :)))");
            return null;
        }
    }
}
