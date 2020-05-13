using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace ModernLangToolsApp
{
    [XmlRoot("Jedi")]
    public class Jedi
    {
        //ezeket lehet auto propertyvel csinálni
        [XmlAttribute("Név")]
        public string Name { set; get; }

        [XmlAttribute("_MidiChlorianSzám")]
        private int midiChlorianCount;

        public Jedi(string name, int midiChlorianCount)
        {
            Name = name;
            MidiChlorianCount = midiChlorianCount;
        }

        [XmlAttribute("MidiChlorianSzám")]
        public int MidiChlorianCount
        {
            //"Getter"
            get { return midiChlorianCount; }
            //Amennyiben negatívba menne a számláló akkor igaz jedihez híven kivételt dob.
            set
            {
                if (value < 0) throw new ArgumentException("You are not a true jedi!");
                else midiChlorianCount = value;
            }
        }

        [Description("Feladat2")]
        public Jedi Clone()
        {
            //elöször kiírjuk a mostani objektumunkat
            XmlSerializer serializer = new XmlSerializer(typeof(Jedi));
            FileStream stream = new FileStream("jedi.txt", FileMode.Create);
            //azért kell a 'this', ugyanis ez a metódus a Jedi osztályhoz tartozik, és ezt az osztályt szerializáljuk
            serializer.Serialize(stream, this);
            stream.Close();

            //itt már beolvassuk a fájlt, egy lokális változóba, amivel visszatérünk
            XmlSerializer ser = new XmlSerializer(typeof(Jedi));
            FileStream fs = new FileStream("jedi.txt", FileMode.Open);
            Jedi clone = (Jedi)ser.Deserialize(fs);
            fs.Close();

            return clone;
        }
    }
}

