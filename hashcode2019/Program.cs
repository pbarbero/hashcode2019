using hashcode2019.lib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Linq;

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
                Console.WriteLine("Press a key to continue...");
                var lines = ReadFile(file);
                var slides = FileParser.Parse(lines);
                var gooderSlides = getHorizontals(slides);
            }
           // var foo = Console.ReadKey();
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
        private static List<Slide> getHorizontals(List<Slide> slides)
        {
            var verticals = new List<Slide>();
                var horizontals = new List<Slide>();
                foreach (Slide slide in slides)
                {
                    if (slide.IsVertical)
                    {
                        verticals.Add(slide);
                    }
                    else
                    {
                        horizontals.Add(slide);
                    }
                }

                var i = 0;
                foreach (Slide slide in verticals){
                    i++;
                    List<Slide> sublist = verticals.GetRange(i, verticals.Count() - i); 
                    var maxValue = 0;
                    var chosen = new Slide(); //The chosen one, that will bring balance to the Force
                    var used = new List<string>(); //Used, like my heart.
                    foreach(Slide otherSlide in sublist){
                        if (used.Contains(otherSlide.Id))
                        {
                            var tempValue = Math.Abs(slide.Tags.Except(otherSlide.Tags).Count() + otherSlide.Tags.Except(slide.Tags).Count());
                            if (tempValue > maxValue)
                            {
                                maxValue = tempValue;
                                chosen = otherSlide;
                            }
                        }
                    }
                    slide.Id = slide.Id + " " + chosen.Id;
                    slide.Tags.AddRange(chosen.Tags);
                    used.Add(chosen.Id);
                    horizontals.Add(slide);
                }
                return horizontals;
            }
        
    }
}


