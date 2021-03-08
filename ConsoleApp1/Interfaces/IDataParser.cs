using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataParser
{
    public interface IDataParser
    {
        ICollection<User> ParseFile(string path);
        bool CanIParse(string extension);
    }
}
