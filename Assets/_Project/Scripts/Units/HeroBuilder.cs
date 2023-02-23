using System.Collections;
using System.Collections.Generic;
using Descending.Attributes;
using Descending.Core;
using UnityEngine;

namespace Descending.Units
{
    public static class HeroBuilder
    {
        public static GameObject SpawnWorldPrefab(Genders gender, RaceDefinition race, Transform parent)
        {
            if (gender == Genders.Male) return GameObject.Instantiate(race.PrefabMale, parent);
            else if (gender == Genders.Female) return GameObject.Instantiate(race.PrefabFemale, parent);
            else return null;
        }
        
        public static GameObject SpawnPortraitPrefab(Genders gender, RaceDefinition race, Transform parent)
        {
            if (gender == Genders.Male) return GameObject.Instantiate(race.PrefabMale, parent);
            else if (gender == Genders.Female) return GameObject.Instantiate(race.PrefabFemale, parent);
            else return null;
        }
    }
}
