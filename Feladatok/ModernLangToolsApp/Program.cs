using System;
using System.Collections.Generic;

namespace ModernLangToolsApp
{
    class Program
    {
        static void MessageReceived(string message)
        {
            //A kapott üzenet kiírásra kerül pl. új taggal való bővülés
            Console.WriteLine(message);
        }

        public static void fill(JediCouncil jc)
        {
            //Példa jedik hozzáadása
            jc.Add(new Jedi("Anakin", 27000));
            jc.Add(new Jedi("Obi-wan", 19000));
            jc.Add(new Jedi("Shaak Ti", 4000));
            jc.Add(new Jedi("Ashoka", 4500));
        }

        static void Main(string[] args)
        {
            //Példa tanács létrehozása
            JediCouncil council = new JediCouncil();
            //Feliratkozás a függvényre
            council.CouncilChanged += MessageReceived;

            //Feltöltés
            fill(council);

            //Kezdők kiírása
            council.WhoIsBeginner();

            //Egyesével mindenki eltávolítása, a végén elesik a tanács
            council.Remove();
            council.Remove();
            council.Remove();
            council.Remove();
            Console.ReadKey();
        }
    }
}
