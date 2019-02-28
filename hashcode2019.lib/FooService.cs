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
            var minimun = 0;
            var slideIdToProcess = slides.First().Id;
            var idsOfSlides = new List<string>(){slideIdToProcess};
            var continueProcess = true;
            var i = 0;

            while (continueProcess)
            {
                var slide = slides.FirstOrDefault(x => x.Id == slideIdToProcess);
                var slidesToCompare = slides.Where(x => !idsOfSlides.Contains(x.Id) && x.Id != slideIdToProcess).ToList();
                
                var nextSlideId = GetBestSlide(slide, slidesToCompare, minimun, slide.Tags.Count() / 2);

                if (!string.IsNullOrEmpty(nextSlideId))
                {
                    slideIdToProcess = nextSlideId;
                    idsOfSlides.Add(nextSlideId);
                }
                

                

                continueProcess = slides.Count() > idsOfSlides.Count();
            }

            return idsOfSlides;
        }

        private string GetBestSlide(Slide slide, List<Slide> slides, int min, int exact)
        {
            foreach (var slideToCompare in slides)
            {
                if (slide.Id != slideToCompare.Id && GetLenghtOfCommonTags(slide, slideToCompare) == exact)
                {
                    return slideToCompare.Id;
                }
            }

            foreach (var slideToCompare in slides)
            {
                if (slide.Id != slideToCompare.Id && GetLenghtOfCommonTags(slide, slideToCompare) > min)
                {
                    return slideToCompare.Id;
                }
            }

            return string.Empty;
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
