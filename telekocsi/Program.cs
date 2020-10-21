using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace telekocsi
{
    
    class Program
    {
        static List<auto> autok = new List<auto>();
        static List<igeny> igenyek = new List<igeny>();

        static void beolv()
        {
            StreamReader sr = new StreamReader("autok.csv");
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                autok.Add(new auto(sr.ReadLine()));
            }
        }

        static void beolv2()
        {
            StreamReader sr = new StreamReader("igenyek.csv");
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                igenyek.Add(new igeny(sr.ReadLine()));
            }


        }
        static void masodik()
        {
            Console.WriteLine(autok.Count());
        }

        static void harmas()
        {
            int ferohely = 0;
            foreach (var t in autok)
            {
                if (t.Indulas == "Budapest" && t.Cel == "Miskolc")
                {
                    ferohely +=t.Ferohely;
                }
            }
            
            Console.WriteLine("Összesen {0} férőhelyet hirdettek meg",ferohely);
        }

        static void negyes()
        {
            Dictionary<string, int> utvonal = new Dictionary<string, int>();

            foreach (var t in autok)
            {
                if (!utvonal.ContainsKey(t.utvonalak))
                {
                    utvonal.Add(t.utvonalak, t.Ferohely);
                }
                else
                {
                    utvonal[t.utvonalak] = utvonal[t.utvonalak] + t.Ferohely;
                }
            }


            int max = 0;
            string utv = "";
            foreach (var u in utvonal)
            {
                if (u.Value > max)
                {
                    max = u.Value;
                    utv = u.Key;
                }
            }


            
            
            //int max = 0;
            //int index = 0;
            //for (int i = 0; i < autok.Count; i++)
            //{
            //    if (max < autok[i].Ferohely)
            //    {
            //        max = autok[i].Ferohely;
            //        index = i;
            //    }
            //}
            //foreach (var t in autok)
            //{
            //    if (t.Ferohely == max)
            //    {
            //        Console.WriteLine($"A legtöbb férőhelyet {max}-ot) az {t.Indulas} - {t.Cel} útvonalon ajánlották fel a hirdetők");
            //    }
            //}



        }

        static void otos()
        {

            foreach (var igeny in igenyek)
            {
                int i = 0;
                while (i < autok.Count && !(igeny.Indulas == autok[i].Indulas &&
                    igeny.Cel == autok[i].Cel &&
                    igeny.Szemelyek <= autok[i].Ferohely))
                {
                    i++;
                }
                if (i < autok.Count)
                {
                    Console.WriteLine($"{igeny.Azonosito} => {autok[i].Rendszam}");
                }
            }
        }








        //    for (int i = 0; i < autok.Count; i++)
        //    {
        //        for (int j = 0; j < igenyek.Count; j++)
        //        {
        //            if (autok[i].Indulas == igenyek[j].Indulas && autok[i].Cel == igenyek[j].Cel && 
        //                autok[i].Ferohely > igenyek[j].Szemelyek)
        //            {
        //                Console.WriteLine($"\t{igenyek[j].Azonosito} => {autok[i].Rendszam}");
        //            }
        //        }
        //    }
        //}

        static void hatos()
        {
            StreamWriter sw = new StreamWriter("utasvalami.txt");
            foreach (var igeny in igenyek)
            {
                int i = 0;
                while (i < autok.Count && !(igeny.Indulas == autok[i].Indulas &&
                    igeny.Cel == autok[i].Cel &&
                    igeny.Szemelyek <= autok[i].Ferohely))
                {
                    i++;
                }
                if (i < autok.Count)
                {
                    Console.WriteLine($"{igeny.Azonosito} => {autok[i].Rendszam}");
                }
                sw.Close();
            }










            //StreamWriter sw = new StreamWriter("utasuzenetek.txt");
            //for (int i = 0; i < igenyek.Count; i++)
            //{
            //    for (int j = 0; j < autok.Count; j++)
            //    {
            //        if (autok[j].Indulas == igenyek[i].Indulas && autok[j].Cel == igenyek[i].Cel)
            //        {
            //            sw.WriteLine($"{igenyek[i].Azonosito}: Rendszám:{autok[j].Rendszam}: Telefonszám:{autok[j].Telefonszam}");
            //        }
            //    }
            //    sw.WriteLine($"{igenyek[i].Azonosito}: Sajnos nem sikerült találni");
            //}
            //sw.Close();
        }
        static void Main(string[] args)
        {
            beolv();
            beolv2();
            masodik();
            harmas();
            negyes();
            otos();
            hatos();
            //foreach (var t in igenyek)
            //{
            //    Console.WriteLine(t.Azonosito + ";" + t.Indulas + ";" + t.Cel + ";" + t.Szemelyek);
            //}

            Console.ReadKey();

        }
    }
}
