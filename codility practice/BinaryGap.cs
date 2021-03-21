﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace codility_practice
{
    class BinaryGap
    {
        public int solution(int N)
        {
            N = 9898;
            string binary = Convert.ToString(N, 2);
            var split = binary.ToCharArray();

            var counter = 0;
            bool foundOne = false;
            List<int> counterList = new List<int>();

            for(int i = 0; i < split.Length; i++)
            {
                if (split[0] == '1' && i == 0)
                {
                    foundOne = true;
                }
                else if (split[i] == '0')
                {
                    counter++;
                    if(i == split.Length - 1)
                    {
                        counterList.Add(counter);
                    }
                }
                else if (split[i] == '1' && split[i - 1] == '0')
                {
                    counterList.Add(counter);
                    counter = 0;
                }             
            }

            int solution = counterList.Max();
            return solution;
        }
    }
}
