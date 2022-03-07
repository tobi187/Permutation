using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermutationTest.Models
{
    internal class Computation
    {
        internal Computation(List<Ebene> data)
        {
            ebeneList = data;
            var tableAmount = ebeneList[0].Tables.Count;
            perms = GetPermutations(Enumerable.Range(1, tableAmount), tableAmount).ToList();
            firstEbene = ebeneList[0];
            firstEbene.SortAllTables();
        }
        List<Ebene> ebeneList;
        List<IEnumerable<int>> perms;
        Ebene firstEbene;
        public int amountSaved = 0;
        public int amountGes = 0;

        public Result DoComputation(List<IEnumerable<int>> history, IEnumerable<int> lastVal)
        {
            var result = new Result()
            {
                tables = firstEbene.Tables
            };
            var lastTableOrder = Enumerable.Range(1, firstEbene.Tables.Count);
            
            history.Add(lastVal);

            var misery = history.ToList();

            for (var ebeneCounter = 1; ebeneCounter < misery.Count + 1; ebeneCounter++)
            {
                var h = misery[ebeneCounter - 1];
                var currEbene = ebeneList[ebeneCounter];
                var tableA = lastTableOrder.Zip(h, (l, c) => 
                        new { l, c }).ToDictionary(item => item.l, item => item.c);
                result.tables = currEbene.AddEbene(result.tables);
                if (ebeneCounter != misery.Count)
                    result.SortAllTables();
                result.workFlow.Add(tableA);
                foreach (var z in result.tables)
                {
                    Console.WriteLine("RandomNums: " + "[{0}]", string.Join(", ", z.RandomNums));
                    Console.WriteLine("InitalOrder: " + "[{0}]", string.Join(", ", z.InitalOrder));
                    Console.WriteLine("Values: " + "[{0}]", string.Join(", ", z.Values));
                }
            }

            return result;
        }

        public IEnumerable<IEnumerable<int>> GetPermutations(IEnumerable<int> list, int length)
        {
            if (length == 1) return list.Select(t => new int[] { t });

            return GetPermutations(list, length - 1)
                .SelectMany(t => list.Where(e => !t.Contains(e)),
                    (t1, t2) => t1.Concat(new int[] { t2 }));
        }

        public List<Result> RecursivePerm(int am, List<IEnumerable<int>> history, List<Result> results)
        {
            if (am == 0) {
                Console.WriteLine("History: " + history.Count);
                var currPerm = history.ToList();
                history.Clear();
                foreach (var i in perms)
                {
                    results.Add(DoComputation(currPerm.ToList(), i));
                    amountGes++;
                }
            }
            else
            {
                foreach (var i in perms)
                {
                    history.Add(i);
                    RecursivePerm(am - 1, history, results);
                }
            }
            return results;
        }

    }
}
