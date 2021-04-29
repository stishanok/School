using System;
using System.Collections.Generic;
using Model.Entity;

namespace View
{
    public static class Print
    {
        private const string LIST_IS_EMPTY = "Sorry, pupils is empty...";
        
        public static string Show(IEnumerable<Pupil> list)
        {
            string result = "";
            
            IEnumerator<Pupil> iterator = list.GetEnumerator();

            while (iterator.MoveNext())
            {
                result += iterator.Current + "\n";
            }

            return result.Length != 0? result : LIST_IS_EMPTY;
        }
    }
}