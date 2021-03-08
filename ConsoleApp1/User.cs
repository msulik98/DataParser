using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataParser
{
    public class User
    {
        public IDisplay Display { get; set; }
        public string Email { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public User()
        {
            Display = new ConsoleDisplay();
        }
        public User(IDisplay display)
        {
            Display = display;
        }
        public void DisplayMe()
        {
            Display.DisplayUser(this);
        }
    }
}
