using System;
using System.Collections;
using System.Collections.Generic;
using Model.Entity;

namespace Model.Logic
{
    public class Manager
    {
        private const float PUPIL_MIN_RATING = 0;
        private const float PUPIL_MAX_RATING = 10;
        
        public static float CalculateAvgRating(IEnumerable<Pupil> list)
        {
            float avg = 0;
            int count = 0;

            IEnumerator<Pupil> iterator = list.GetEnumerator();

            while (iterator.MoveNext())
            {
                avg += iterator.Current.Rating;
                count++;
            }

            return (float)Math.Round(avg / count, 1);
        }
        
        public static IList<Pupil> GetPupilsMaxRating(IEnumerable<Pupil> list)
        {
            IList<Pupil> result = new List<Pupil>();
            float maxRating = FindMaxRating(list);

            if (maxRating != -1)
            {
                IEnumerator<Pupil> iterator = list.GetEnumerator();

                while (iterator.MoveNext())
                {
                    if (iterator.Current.Rating == maxRating)
                    {
                        result.Add(iterator.Current);
                    }
                }
            }

            return result;
        }
        
        public static IList<Pupil> GetPupilsMinRating(IEnumerable<Pupil> list)
        {
            IList<Pupil> result = new List<Pupil>();
            float minRating = FindMinRating(list);

            if (minRating != -1)
            {
                IEnumerator<Pupil> iterator = list.GetEnumerator();

                while (iterator.MoveNext())
                {
                    if (iterator.Current.Rating == minRating)
                    {
                        result.Add(iterator.Current);
                    }
                }
            }

            return result;
        }

        private static float FindMaxRating(IEnumerable<Pupil> list)
        {
            float maxRating = PUPIL_MIN_RATING;
            
            IEnumerator<Pupil> iterator = list.GetEnumerator();

            while (iterator.MoveNext())
            {
                if (iterator.Current.Rating > maxRating )
                {
                    maxRating = iterator.Current.Rating;
                }
            }

            return maxRating;
        }
        
        private static float FindMinRating(IEnumerable<Pupil> list)
        {
            float minRating = PUPIL_MAX_RATING;
            
            IEnumerator<Pupil> iterator = list.GetEnumerator();

            while (iterator.MoveNext())
            {
                if (iterator.Current.Rating < minRating)
                {
                    minRating = iterator.Current.Rating;
                }
            }

            return minRating;
        }
    }
}