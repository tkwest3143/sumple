using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Model
{
    class MaxWeight
    {
        private int maxWeight;
        public int getMaxWeight(string big3_name,int weight,int rep)
        {
            if (big3_name.Equals("benchpress"))
            {
                this.maxWeight = BenchpressMax(weight, rep);
            }
            else
            {
                this.maxWeight = sothingElse(weight, rep);
            }
            return this.maxWeight;
        }

        private int sothingElse(int weight, int rep)
        {
            int maxweight0 = (int)(weight * rep / 33.3 + weight);
            return maxweight0;
        }

        private int BenchpressMax(int weight, int rep)
        {
            int maxweight0 = (int)(weight * rep / 40 + weight);
            return maxweight0;
        }
    }
}
