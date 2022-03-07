using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermutationTest.Models
{
    internal class Result
    {
        public List<Table> tables = new List<Table>();
        public List<Dictionary<int, int>> workFlow = new List<Dictionary<int, int>>();

        public void SortAllTables()
        {
            foreach (var table in tables)
            {
                table.SortNums();
            }
        }
    }


}
