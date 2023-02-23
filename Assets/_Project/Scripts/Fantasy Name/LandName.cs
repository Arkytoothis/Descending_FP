using UnityEngine;
using System.Collections.Generic;

namespace Descending.Units
{
    public static class LandName
    {
        public static string[] LandsPart1 = new string[] { "Dagger", "Broken", "Shining", "Sword", "Dragon", "Forgotten", "Black", "North", "South", "White", "Haunted", "Shadow", "Misty", "Splintered", "Sparkling", "Goblin" };
        public static string[] LandsPart2 = new string[] { "Coast", "Hills", "Lands", "Isles", "Keep", "Marsh", "Island", "Vale", "Mountain", "Forest", "Creek", "Falls" };

        public static string[] LandsPartA = new string[] { "Cor", "Car", "Cer", "Dran", "Drun", "Dren", "Fen", "Fan", "Fon", "Len", "Lan", "Lon", "An", "En", "Un", "Ra", "Ro", "Kan", "Kun", "Kon" };
        public static string[] LandsPartB = new string[] { "kor", "ker", "kar", "gar", "gor", "ger", "tar", "tor", "ter", "thyr", "myr", "ther", "thar", "thor" };

        public static string[] TownsEndA = new string[] { "ton", "vil", "ville", " Town", " Towne" };

        public static string Generate()
        {
            string landName = "";

            int weight = GetWeight();

            if (weight < 33)
            {
                landName = GetRandomElement(LandsPart1) + " " + GetRandomElement(LandsPart2);
            }
            else if (weight < 66)
            {
                landName = GetRandomElement(LandsPartA) + GetRandomElement(LandsPartB);
            }
            else
            {
                landName = GetRandomElement(LandsPartA) + GetRandomElement(LandsPartB) + " " + GetRandomElement(LandsPart2);
            }

            return landName;
        }

        public static string GeneratePlaceName()
        {
            string landName = "";

            int weight = GetWeight();

            if (weight < 33)
            {
                landName = GetRandomElement(LandsPart1) + " " + GetRandomElement(LandsPart2);
            }
            else if (weight < 66)
            {
                landName = GetRandomElement(LandsPartA) + GetRandomElement(LandsPartB);
            }
            else
            {
                landName = GetRandomElement(LandsPartA) + GetRandomElement(LandsPartB) + " " + GetRandomElement(LandsPart2);
            }

            return landName;
        }

        public static string GenerateTownName()
        {
            string landName = "";

            int weight = GetWeight();

            if (weight < 33)
            {
                landName = GetRandomElement(LandsPart1) + " " + GetRandomElement(LandsPart2);
            }
            else if (weight < 66)
            {
                landName = GetRandomElement(LandsPartA) + GetRandomElement(LandsPartB) + GetRandomElement(TownsEndA);
            }
            else
            {
                landName = GetRandomElement(LandsPartA) + GetRandomElement(LandsPartB) + " " + GetRandomElement(LandsPart2);
            }

            return landName;
        }

        static string GetRandomElement(string[] array)
        {
            int index = Random.Range(0, array.Length);
            return array[index];
        }

        static int GetWeight()
        {
            return Random.Range(0, 100);
        }
    }
}