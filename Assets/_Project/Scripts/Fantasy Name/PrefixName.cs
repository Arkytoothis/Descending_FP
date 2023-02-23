using UnityEngine;
using System.Collections.Generic;
using Descending.Core;

namespace Descending.Units
{
    public static class PrefixName
    {
        public static string[] MaleNamePrefix = new string[] { "Sir", "Lord", "Mr", "Sire" };
        public static string[] FemaleNamePrefix = new string[] { "Lady", "Mrs", "Miss" };

        public static string Generate(int prefix_chance, FantasyName name, Genders gender, string race)
        {
            string prefix = "";

            if (Random.Range(0, 100) < prefix_chance)
            {
                if (gender == Genders.Male)
                {
                    prefix = MaleNamePrefix[Random.Range(0, MaleNamePrefix.Length)];
                }
                else if (gender == Genders.Female)
                {
                    prefix = FemaleNamePrefix[Random.Range(0, FemaleNamePrefix.Length)];
                }
            }

            return prefix;
        }
    }
}