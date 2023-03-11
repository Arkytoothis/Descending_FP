using Descending.Gui;
using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[AddComponentMenu(SOArchitecture_Utility.EVENT_LISTENER_SUBMENU + "HeroDamageText")]
	public sealed class HeroDamageTextGameEventListener : BaseGameEventListener<HeroDamageText, HeroDamageTextGameEvent, HeroDamageTextUnityEvent>
	{
	}
}