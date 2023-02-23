using UnityEngine;
using System.Collections.Generic;
using Descending.Core;

namespace Descending.Units
{
    public static class NameGenerator
    {
        public static FantasyName Get(Genders gender, string race, string profession)
        {
            FantasyName name = new FantasyName();

            name.FirstName = FirstName.Generate(name, gender, race);
            name.LastName = LastName.Generate(name, profession);
            name.Title = PrefixName.Generate(50, name, gender, race);
            name.Postfix = PostfixName.Generate(50, name, gender, race);
            name.Land = LandName.Generate();

            return name;
        }
    }
}