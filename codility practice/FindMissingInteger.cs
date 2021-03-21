using System;
using System.Collections.Generic;
using System.Text;

namespace codility_practice
{
    class FindMissingInteger
    {
        public static int solution(int[] A)
        {
            HashSet<int> hash = new HashSet<int>(A);
            var noDuplicates = hash;

            int[] cleanArray = new int[noDuplicates.Count];

            noDuplicates.CopyTo(cleanArray);

            Array.Sort(cleanArray);
            var found = 1;
            for (int i = 0; i < cleanArray.Length; i++)
            {
                if (cleanArray[i] <= 0)
                {
                    continue;

                }
                else if (cleanArray[i] == found)
                {
                    found++;
                }

            }

            return found;

        }
    }
}
