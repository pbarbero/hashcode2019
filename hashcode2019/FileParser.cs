using System;
using System.Collections.Generic;
using System.Linq;

namespace hashcode2019
{
    public static class FileParser
    {
        public static object Parse(IEnumerable<string> lines)
        {
            throw new NotImplementedException();
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
