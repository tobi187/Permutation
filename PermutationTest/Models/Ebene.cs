using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PermutationTest.Models;

namespace PermutationTest.Models
{
    internal class Ebene
    {
        public int Count{ get; set; }
        public List<Table> Tables = new List<Table>();
        
        public void SortAllTables()
        {
            foreach (var table in Tables)
            {
                table.SortNums();
            }
        }

        public void ReOrderTables(IEnumerable<int> newOrder)
        {
            var newTableOrder = new List<Table>();
            foreach (var i in newOrder)
            {
                // check this again
                newTableOrder.Add(Tables[i - 1]);
            }
            Tables = newTableOrder;
        }

        public List<Table> AddEbene(List<Table> toAdd)
        {
            var newValues = new List<Table>();
            for (var i = 0; i < toAdd.Count; i++)
            {
                var newVals = (Tables[i].Values.Zip(toAdd[i].Values, (x, y) => x + y)).ToArray();
                newValues.Add(
                    new Table() 
                    { 
                        Values = newVals, 
                        InitalOrder = Tables[i].InitalOrder,
                        RandomNums = Tables[i].RandomNums
                    });
            }
            return newValues;
        }
    }
}
