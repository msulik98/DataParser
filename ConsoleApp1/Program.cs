using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DataParser
{
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
}
