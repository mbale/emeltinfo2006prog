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
            #region "1. és 2. Feladat"
            List<Protein> proteins = new List<Protein>();
            string[] unsortedproteinlist = File.ReadAllLines("data/aminosav.txt");

            int count = 0;
            List<string> buffer = new List<string>();
                 
            foreach (var item in unsortedproteinlist)
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
                            RelativeAtomicMass = int.Parse(buffer[2]) * 12 + int.Parse(buffer[3]) * 1 + int.Parse(buffer[4]) * 16 + int.Parse(buffer[5]) * 14 + int.Parse(buffer[6]) * 32,
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

            #region "3. Feladat"
            var orderedproteinsbyatomicmass = proteins.OrderBy(protein => protein.RelativeAtomicMass);
            var proteinsbynameandmass = proteins.Select(protein => protein.ShortName + " " + protein.RelativeAtomicMass);

            foreach (var item in proteinsbynameandmass)
            {
                using (StreamWriter rw = File.AppendText("data/eredmeny.txt"))
                {
                    rw.WriteLine(item);
                }
            } 
            #endregion

            Console.ReadLine();
        }

        class Protein
        {
            public string ShortName { get; set; }
            public char Symbol { get; set; }
            public int RelativeAtomicMass { get; set; }
            public int C { get; set; } // szén 12
            public int H { get; set; } // hidrogén 1
            public int O { get; set; } // oxigén 16
            public int N { get; set; } // nitrogén 14
            public int S { get; set; } // kén 32
        }
    }
}
