using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace KATAs
{
    public class TheHighestProfitWins
    {
        public int[] MinMax(int[] arrayOfCosts)
        {
            int min = 0, max = 0;

            min = max = arrayOfCosts[0];

            foreach (int cost in arrayOfCosts)
            {
                if (min > cost)
                {
                    min = cost;
                }

                if (max < cost)
                {
                    max = cost;
                }
            }

            return new int[] { min, max };
        }

        /* Best Practice
        public int[] MinMax(int[] lst)
        {
            return new int[] {lst.Min(), lst.Max()};
        }
         */
    }
}
