using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermutationWPF.Models
{
    internal class Table
    {
        public int Count { get; set; }
        public int[]? RandomNums { get; set; }
        public int[]? Values { get; set; }  
        public int[]? InitalOrder { get; set; }

    //grün orange gelb rot

        public void SortRanNums()
        {
            var combined = InitalOrder!.Zip(RandomNums!, (f, s) => new {f, s})
                .ToDictionary(item => item.f, item => item.s);
            combined.OrderBy(x => x.Value);
            InitalOrder = combined.Keys.ToArray();
            RandomNums = combined.Values.ToArray(); 
        }
    }
}
