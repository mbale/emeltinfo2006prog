using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections;

namespace emeltinfo2006
{
    class Program
    {
        static void Main(string[] args)
        {
            #region "1. Feladat"
            List<Protein> proteins = new List<Protein>();
            string[] d = File.ReadAllLines("data/aminosav.txt");

            int count = 0;
            List<string> buffer = new List<string>();
                 
            foreach (var item in d)
            {
                buffer.Add(item);
                count++;

                // emptying buffer
                if (count == 7)
                {
                        proteins.Add(new Protein() 
                        {
                            ShortName = buffer[0].ToString(), 
                            Symbol = char.Parse(buffer[1]), 
                            C = int.Parse(buffer[2]), 
                            H = int.Parse(buffer[3]), 
                            O = int.Parse(buffer[4]), 
                            N = int.Parse(buffer[5]), 
                            S = int.Parse(buffer[6]) 
                        });
                    buffer.Clear();
                    count = 0;
                }
            }
            #endregion

            #region "2. Feladat"
            Dictionary<string, int> relativeatomicmass = new Dictionary<string, int>();
            //var pl = proteins.Select(x => x.ShortName + x.C + x.H + x.O).spl;
            #endregion

            //foreach (var item in pl)
            //{
            //    Console.WriteLine(item.ToString());
            //}

            Console.ReadLine();
        }

        class Protein
        {
            public string ShortName { get; set; }
            public char Symbol { get; set; }
            public int C { get; set; } // szén
            public int H { get; set; } // hidrogén
            public int O { get; set; } // oxigén
            public int N { get; set; } // nitrogén
            public int S { get; set; } // kén
        }
    }
}
