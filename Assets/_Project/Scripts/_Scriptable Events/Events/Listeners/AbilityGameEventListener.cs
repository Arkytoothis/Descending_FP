using Descending.Abilities;
using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[AddComponentMenu(SOArchitecture_Utility.EVENT_LISTENER_SUBMENU + "Ability")]
	public sealed class AbilityGameEventListener : BaseGameEventListener<Ability, AbilityGameEvent, AbilityUnityEvent>
	{
	}
}