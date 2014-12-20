using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace YAML
{
    //------------------------------------------------------------------
    class Program
    {
        static void Main (string[] args)
        {
            var input = new StreamReader ("Example.yaml");

            var deserializer = new Deserializer ();

            var test = deserializer.Deserialize<Testing> (input);

            Console.WriteLine (test.Id + ": " + test.Name);

            foreach (var item in test.Parts)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey (true);

        }
    }

    //------------------------------------------------------------------
    class Testing
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List <string> Parts { get; set; }
    }
}