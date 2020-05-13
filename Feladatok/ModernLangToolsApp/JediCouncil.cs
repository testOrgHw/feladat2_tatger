using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ModernLangToolsApp
{
    //Delegálttípus definíció
    public delegate void CouncilChangedDelegate(string message);
    //3-as feladat: a Jeditanács, eventjelzéssel (új tag érkezésekor, elhagyáskor és ha elesett a tanács)
    [Description("Feladat3")]
    class JediCouncil
    {
        public event CouncilChangedDelegate CouncilChanged;

        List<Jedi> members = new List<Jedi>();
        public void Add(Jedi newJedi)
        {
            members.Add(newJedi);
            if (CouncilChanged != null)
                CouncilChanged("Új taggal bővültünk");
        }
        public void Remove()
        {
            // Eltávolítja a lista legutolsó pozícióban lévő elemét
            members.RemoveAt(members.Count - 1);
            if (CouncilChanged != null)
            {
                if (members.Count > 0)
                    CouncilChanged("Zavart érzek az erőben");
                else
                    CouncilChanged("A tanács elesett!");
            }
        }


        [Description("Feladat4")]
        public List<Jedi> GetBeginners()
        {
            //Predikátumot váró FindAll metódus
            return members.FindAll(isUnder300);
        }

        //A várt predikátum
        public bool isUnder300(Jedi j)
        {
            //Egyszerű értékellenőrzés j<300 ? true, false
            return j.MidiChlorianCount < 300;
        }

        public void WhoIsBeginner()
        {
            //Lekérdezzük az újoncokat
            List<Jedi> jedis = GetBeginners();

            //Egyszerű névkiírás
            foreach (Jedi j in jedis)
            {
                Console.WriteLine(j.Name);
            }
        }

    }
}
