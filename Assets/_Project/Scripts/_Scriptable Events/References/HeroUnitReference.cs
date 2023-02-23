using Descending.Units;
using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class HeroUnitReference : BaseReference<HeroUnit, HeroUnitVariable>
	{
	    public HeroUnitReference() : base() { }
	    public HeroUnitReference(HeroUnit value) : base(value) { }
	}
}