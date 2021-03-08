using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataParser
{
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
}
