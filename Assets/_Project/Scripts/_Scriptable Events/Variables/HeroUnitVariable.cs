using Descending.Units;
using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public class HeroUnitEvent : UnityEvent<HeroUnit> { }

	[CreateAssetMenu(
	    fileName = "HeroUnitVariable.asset",
	    menuName = SOArchitecture_Utility.VARIABLE_SUBMENU + "new HeroUnitEvent",
	    order = 120)]
	public class HeroUnitVariable : BaseVariable<HeroUnit, HeroUnitEvent>
	{
	}
}