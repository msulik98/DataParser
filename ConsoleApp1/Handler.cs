using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataParser
{
    public class Handler
    {
        protected Handler successor = null;
        private IDataParser parser;
        public Handler(IDataParser parser) => this.parser = parser;
        public void SetSuccessor(Handler successor)
        {
            this.successor = successor;
        }

        public ICollection<User> HandleRequest(string path)
        {
            string extension = path.Split('.').Last();
            if (parser.CanIParse(extension))
            {
                return parser.ParseFile(path);
            }
            else if (successor != null)
            {
                successor.HandleRequest(path);
            }
            return null;
        }
    }
}
