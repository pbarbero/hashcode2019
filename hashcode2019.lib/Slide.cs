using System.Collections.Generic;

namespace hashcode2019.lib
{
    public class Slide
    {
        
        public string Id { get; set; }
        public List<string> Tags { get; set; }

        public bool IsVertical {get; set;}

        public Slide (){
            this.Tags = new List<string>();
        }
        
    }
        
}