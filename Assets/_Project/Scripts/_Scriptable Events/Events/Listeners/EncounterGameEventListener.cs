using Descending.Encounters;
using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[AddComponentMenu(SOArchitecture_Utility.EVENT_LISTENER_SUBMENU + "Encounter")]
	public sealed class EncounterGameEventListener : BaseGameEventListener<Encounter, EncounterGameEvent, EncounterUnityEvent>
	{
	}
}