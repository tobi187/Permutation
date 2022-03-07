using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermutationTest.Models
{
    internal class Table
    {
        public int Count { get; set; }
        public int[]? RandomNums { get; set; }
        public int[]? Values { get; set; }  
        public int[]? InitalOrder { get; set; }

    //grün orange gelb rot

        public void SortNums()
        {
            Array.Sort(RandomNums.ToArray(), Values);
            Array.Sort(RandomNums.ToArray(), InitalOrder);
            Array.Sort(RandomNums);
        }
    }
}
