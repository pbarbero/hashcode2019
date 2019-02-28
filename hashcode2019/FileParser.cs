using System;
using System.Collections.Generic;
using System.Linq;
using hashcode2019.lib;

namespace hashcode2019
{
    public static class FileParser
    {
        public static object Parse(IEnumerable<string> lines)
        {
            var photos = new List<Photo>();
            var allLines = lines.Skip(1);
            var id = 0;

            foreach(var line in allLines)
            {
                var splitedLine = line.Split(" ");
                var photo = new Photo()
                {
                    Horizontal = splitedLine[0][0] == 'H',
                    Id = id
                };

                for(var i = 2; i < splitedLine.Length; i++)
                {
                    photo.Tags.Add(splitedLine[i]);
                }

                photos.Add(photo);
                id++;
            }

            return photos;
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
