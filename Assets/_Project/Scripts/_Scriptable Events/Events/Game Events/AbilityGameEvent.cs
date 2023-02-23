using Descending.Abilities;
using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	[CreateAssetMenu(
	    fileName = "AbilityGameEvent.asset",
	    menuName = SOArchitecture_Utility.GAME_EVENT + "Ability",
	    order = 120)]
	public sealed class AbilityGameEvent : GameEventBase<Ability>
	{
	}
}