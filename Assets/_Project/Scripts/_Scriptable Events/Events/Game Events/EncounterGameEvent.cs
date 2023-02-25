using Descending.Encounters;
using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	[CreateAssetMenu(
	    fileName = "EncounterGameEvent.asset",
	    menuName = SOArchitecture_Utility.GAME_EVENT + "Encounter",
	    order = 120)]
	public sealed class EncounterGameEvent : GameEventBase<Encounter>
	{
	}
}