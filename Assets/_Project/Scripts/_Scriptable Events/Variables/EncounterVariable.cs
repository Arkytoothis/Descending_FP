using Descending.Encounters;
using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public class EncounterEvent : UnityEvent<Encounter> { }

	[CreateAssetMenu(
	    fileName = "EncounterVariable.asset",
	    menuName = SOArchitecture_Utility.VARIABLE_SUBMENU + "Encounter",
	    order = 120)]
	public class EncounterVariable : BaseVariable<Encounter, EncounterEvent>
	{
	}
}