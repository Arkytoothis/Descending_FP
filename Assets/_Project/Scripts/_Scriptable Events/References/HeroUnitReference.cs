using Descending.Units;
using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class HeroUnitReference : BaseReference<Hero, HeroUnitVariable>
	{
	    public HeroUnitReference() : base() { }
	    public HeroUnitReference(Hero value) : base(value) { }
	}
}