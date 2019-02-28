using System;
using System.Collections.Generic;
using System.Linq;
using hashcode2019.lib;

namespace hashcode2019
{
    public static class FileParser
    {
        public static List<Slide> Parse(IEnumerable<string> lines)
        {
            var slides = new List<Slide>();
            var allLines = lines.Skip(1);
            var id = 0;

            foreach(var line in allLines)
            {
                var splitedLine = line.Split(" ");
                var slide = new Slide()
                {
                    IsVertical = splitedLine[0][0] == 'H',
                    Id = id.ToString()
                };

                for(var i = 2; i < splitedLine.Length; i++)
                {
                    slide.Tags.Add(splitedLine[i]);
                }                

                slides.Add(slide);
                id++;
            }

            return slides;
        }

        private static int GetInt(string foo)
        {
            var number = 0;

            if (!Int32.TryParse(foo, out number))
            {
                throw new Exception("Cannot parse file");
            }

            return number;
        }
    }
}
