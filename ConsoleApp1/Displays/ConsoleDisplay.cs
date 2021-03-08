using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataParser
{
    public class ConsoleDisplay : IDisplayable
    {
        public void DisplayUser(User user)
        {
            Console.WriteLine($"Name: {user.Name}, Surname: {user.Surname}, Email: {user.Email} ");
        }
    }
}
