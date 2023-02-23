using UnityEngine;
using System.Collections.Generic;
using Descending.Core;

namespace Descending.Units
{
    public static class PostfixName
    {
        public static string[] MaleNamePostfix = new string[] { "the Unholy", "the Crazed", "the Terrible", "the Cruel", "the Gruesome", "the Boneless", "the Gnarled", "the Broken", "the Underhanded", "the Scalper",
        "the Tormented", "the Virtuous", "the Valiant", "the Unholy", "the Holy", "the Fierce", "the Golden", "the Bold", "the Brash", "the Crazed", "the Great", "the Terrible", "the Cruel", "the Destroyer",
        "the Magnificent", "the Brave", "the Cowardly", "the Mighty", "the One", "the Unavoidable", "the Lion", "the Pious", "I", "II", "III", "IV", "V", "the Black", "the Red", "the Good", "the Boneless",
        "the Great King", "the Restless", "the Peaceful", "the Traveled", "the Deposed", "the Handsome" };

        public static string[] FemaleNamePostfix = new string[] { "the Unholy", "the Crazed", "the Terrible", "the Cruel", "the Gruesome", "the Boneless", "the Gnarled", "the Broken", "the Underhanded", "the Scalper",
        "the Tormented", "the Virtuous", "the Valiant", "the Unholy", "the Holy", "the Fierce", "the Golden", "the Bold", "the Brash", "the Crazed", "the Great", "the Terrible", "the Cruel", "the Destroyer",
        "the Magnificent", "the Brave", "the Cowardly", "the Mighty", "the One", "the Unavoidable", "the Lioness", "the Pious", "I", "II", "III", "IV", "V", "the Black", "the Red", "the Good", "the Boneless",
        "the Great King", "the Restless", "the Peaceful", "the Traveled", "the Deposed", "The Beautiful" };
        public static string Generate(int postfix_chance, FantasyName name, Genders gender, string profession)
        {
            string postfix = "";

            if (Random.Range(0, 100) < postfix_chance)
            {
                if (gender == Genders.Male)
                {
                    postfix = MaleNamePostfix[Random.Range(0, MaleNamePostfix.Length)];
                }
                else if (gender == Genders.Female)
                {
                    postfix = FemaleNamePostfix[Random.Range(0, FemaleNamePostfix.Length)];
                }
            }

            return postfix;
        }
    }
}