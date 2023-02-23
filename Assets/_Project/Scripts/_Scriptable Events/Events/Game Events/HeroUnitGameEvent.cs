using Descending.Units;
using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	[CreateAssetMenu(
	    fileName = "HeroUnitGameEvent.asset",
	    menuName = SOArchitecture_Utility.GAME_EVENT + "new HeroUnitEvent",
	    order = 120)]
	public sealed class HeroUnitGameEvent : GameEventBase<HeroUnit>
	{
	}
}