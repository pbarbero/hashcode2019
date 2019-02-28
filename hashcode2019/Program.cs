using hashcode2019.lib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace hashcode2019
{
    class Program
    {
        static void Main(string[] args)
        {
            var FilesNames = new List<string>()
            {
                @"../../../data/a_example.txt",
                //@"../../../data/b_lovely_landscapes.in",
                //@"../../../data/c_memorable_moments.in",
                //@"../../../data/d_pet_pictures.in",
                //@"../../../data/e_shiny_shelfies.in"
            };


            var service = new FooService();

            foreach (var file in FilesNames)
            {
                Console.Write("Press a key to continue...");
                var lines = ReadFile(file);
                var line = FileParser.Parse(lines);
                foreach (Slide slide in line)
                {

                }
                Console.Write(line);
                //service.DoStuff();

                WriteOutFile(line, file);
            }

            var foo = Console.ReadKey();
            Console.Write("Bye!");
        }

        private static void WriteOutFile(object foo, string file)
        {
            //Console
            Console.WriteLine($"Printing {foo.GetType().Name}");
            

            //File
            using (StreamWriter writetext = new StreamWriter(@"../../../output/" + Path.GetFileName(file) + ".out"))
            {
                var stringBuilder = new StringBuilder(string.Empty);

                //foreach (var slice in pizza.Slices)
                //{
                //    stringBuilder.Append($"{slice.GetMinCell().X} {slice.GetMinCell().Y} {slice.GetMaxCell().X} {slice.GetMaxCell().Y}");
                //    stringBuilder.Append("\n");
                //}

                writetext.WriteLine(stringBuilder);
            }
        }

        private static IEnumerable<string> ReadFile(string filePath)
        {
            var frequencies = new List<int>();
            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), filePath);

            return File.ReadLines(path);
        }
    }
}
