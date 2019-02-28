using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using hashcode2019.lib;

namespace hashcode2019.lib
{
    public class FooService
    {
        public List<string> DoStuff(List<Slide> slides)
        {
            var idsOfSlides = new List<string>();

            foreach (var slide in slides)
            {
                var slidesToCompare = slides.Where(x => !idsOfSlides.Contains(x.Id)).ToList();

                if (!idsOfSlides.Contains(slide.Id))
                {
                    var nextSlide = GetBestSlide(slide, slidesToCompare, slide.Tags.Count() / 2);
                    idsOfSlides.Add(nextSlide.Id);
                }
            }

            return idsOfSlides;
        }

        private Slide GetBestSlide(Slide slide, List<Slide> slides, int playa)
        {
            foreach (var slideToCompare in slides)
            {
                if (GetLenghtOfCommonTags(slide, slideToCompare) == playa)
                {
                    return slideToCompare;
                }
            }

            return null;
        }

        private int GetLenghtOfCommonTags(Slide slice1, Slide slice2)
        {
            return GetCommonTags(slice1, slice2).Count();
        }

        private IEnumerable<string> GetCommonTags(Slide slice1, Slide slice2)
        {
            return slice1.Tags.Intersect(slice2.Tags);
        }
    }
}
