using System.Collections.Generic;

namespace hashcode2019.lib
{
    public class Photo
    {
        public Photo()
        {
            Tags = new List<string>();
        }

        public int Id { get; set; }
        public bool Horizontal { get; set; }
        public List<string> Tags { get; set; }
    }
}