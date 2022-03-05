using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermutationTest.Models
{
    internal class Computation
    {
        Computation(List<Ebene> data)
        {
            ebeneList = data;
            var tableAmount = ebeneList[0].Tables.Count;
            perms = GetPermutations(Enumerable.Range(1, tableAmount), tableAmount).ToList();
        }
        List<Ebene> ebeneList;
        List<IEnumerable<int>> perms;
        int amountSaved = 0;
        int amountGes = 0;

        public void doPermutation()
        {
            int amountOfEbenen = ebeneList.Count;

            var perms = GetPermutations(Enumerable.Range(1, amountOfEbenen), amountOfEbenen).ToList();

         

            for (int i = 1; i < ebeneList.Count; i++) { 
                var ebene = ebeneList[i];
                for (int p = 1; p < perms.Count; p++)
                {
                    //var permTable = new Ebene();
                }
            }
        }

        public void DoComputation()
        {
            var results = new List<Result>();
            var obersteEbene = ebeneList[0];
            foreach (var tr1 in perms)
            {
                var currEbene2Tables = new List<Ebene>();
                foreach (var t in tr1)
                {

                }


                var res = new Result();
                foreach (var tr2 in perms)
                {
                    res.workFlow.Add(tr1, tr2);
                }
            }
        }

        public IEnumerable<IEnumerable<int>> GetPermutations(IEnumerable<int> list, int length)
        {
            if (length == 1) return list.Select(t => new int[] { t });

            return GetPermutations(list, length - 1)
                .SelectMany(t => list.Where(e => !t.Contains(e)),
                    (t1, t2) => t1.Concat(new int[] { t2 }));
        }

    }
}
