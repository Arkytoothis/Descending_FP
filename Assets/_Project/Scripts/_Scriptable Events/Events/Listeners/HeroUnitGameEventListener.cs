using Descending.Units;
using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[AddComponentMenu(SOArchitecture_Utility.EVENT_LISTENER_SUBMENU + "HeroUnit")]
	public sealed class HeroUnitGameEventListener : BaseGameEventListener<Hero, HeroUnitGameEvent, HeroUnitUnityEvent>
	{
	}
}