using UnityEngine;
using System.Collections.Generic;

namespace Descending.Units
{
    public static class LastName
    {
        public static string[] LastNamesPart1 = new string[] { "Black", "Dread", "Flame", "Doom", "Iron", "Blood", "Smoke", "Grim" };
        public static string[] LastNamesPart2 = new string[] { "hunter", "bite", "mist", "sinner", "bone", "moon", "rule", "murk", "lust", "heart" };

        public static string Generate(FantasyName name, string profession)
        {
            string lastName = "";

            if (Random.Range(0, 100) < 50)
            {
                lastName = LastNamesPart1[Random.Range(0, LastNamesPart1.Length)] + LastNamesPart2[Random.Range(0, LastNamesPart2.Length)];
            }
            else
            {
                lastName = LastNamesPart1[Random.Range(0, LastNamesPart1.Length)] + LastNamesPart2[Random.Range(0, LastNamesPart2.Length)];
            }

            return lastName;
        }
    }
}