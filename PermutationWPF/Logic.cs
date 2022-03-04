using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermutationWPF
{
    internal class Logic
    {
        Logic(int ebenen, int tabellen, int zahlen)
        {
            AnzahlEbenen = ebenen;
            AnzahlTabellen = tabellen;
            AnzahlZahlen = zahlen;
        }

        public int AnzahlEbenen;
        public int AnzahlTabellen;
        public int AnzahlZahlen;
        
        public void Step(string ebene)
        {
            string[] numbers = ebene.Split(" ");
        }


    }
}
