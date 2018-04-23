using System;

namespace OponeoNET
{
    public class StaticOperatorsOverloading
    {
        public Klasa NewInstance => new Klasa();
    }

    public class Klasa : IEquatable<Klasa>
    {
        public string Name { get; set; } = "CosTam";
        public string FullName { get; set; } = "CosTamWiecej";
        public int WartoscLiczbowa { get; set; } = 3;
        public int Whatever { get; set; } = 4;

        public static Klasa operator +(Klasa ins1, Klasa ins2)
        {
            return new Klasa
            {
                WartoscLiczbowa = ins1.WartoscLiczbowa + ins2.WartoscLiczbowa,
                Whatever = ins1.Whatever + ins2.Whatever,
                Name = ins1.Name + ins2.Name,
                FullName = ins1.FullName + ins2.FullName
            };
        }

        public static bool operator ==(Klasa ins1, Klasa ins2)
        {
            return ins1.FullName == ins2.FullName;
        }

        public static bool operator !=(Klasa ins1, Klasa ins2)
        {
            return ins1 != ins2;
        }

        public override string ToString()
        {
            return $"{Name} {FullName}";
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Klasa);
        }

        public bool Equals(Klasa other)
        {
            return other != null &&
                   Name == other.Name &&
                   FullName == other.FullName &&
                   WartoscLiczbowa == other.WartoscLiczbowa &&
                   Whatever == other.Whatever;
        }
    }
}
