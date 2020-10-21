using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace telekocsi
{
    class igeny
    {
        public string Azonosito { get; private set; }

        public string Indulas { get; private set; }

        public string Cel { get; private set; }
        public int Szemelyek { get; private set; }

        public igeny(string szoveg)
        {
            string[] a = szoveg.Split(';');
            Azonosito = a[0];
            Indulas = a[1];
            Cel = a[2];
            Szemelyek = int.Parse(a[3]);
        }
    }
}
