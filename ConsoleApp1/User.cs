using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataParser
{
    public class User
    {
        private IDisplayable display;
        public string Email { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public User()
        {
            display = new ConsoleDisplay();
        }
        public User(IDisplayable displayable)
        {
            display = displayable;
        }
        public void Display()
        {
            display.DisplayUser(this);
        }
    }
}
