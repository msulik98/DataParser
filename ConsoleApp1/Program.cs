using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

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
    public interface IDataParser
    {
        ICollection<User> ParseFile(string path);
        bool CanIParse(string extension);
    }
    public interface IDisplayable
    {
        void DisplayUser(User user);
    }

    class Program
    {
        static void Main(string[] args)
        {
            string[] files = new string[] {"file.json","file.xml","file.csv"};
            Handler json = new Handler(new JsonParser());
            Handler xml = new Handler(new XMLParser());
            Handler csv = new Handler(new CSVParser());
            json.SetSuccessor(xml);
            xml.SetSuccessor(csv);
            foreach (var file in files)
            {
                var people = json.HandleRequest(file);
                if(people!=null)
                    foreach (var person in people)
                    {
                        person.Display();
                    }
            }


            

        }
    }
    public class JsonParser : IDataParser
    {
        public JsonParser()
        {
        }
        public bool CanIParse(string extension) => extension == "json";

        public ICollection<User> ParseFile(string path)
        {
            string jsonString = File.ReadAllText(path);
            var people = JsonConvert.DeserializeObject<ICollection<User>>(jsonString);
            return people;
        }
    }
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
    public class ConsoleDisplay : IDisplayable
    {
        public void DisplayUser(User user)
        {
            Console.WriteLine($"Name: {user.Name}, Surname: {user.Surname}, Email: {user.Email} ");
        }
    }
}
