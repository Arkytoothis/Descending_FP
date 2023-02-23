using Descending.Equipment;
using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[AddComponentMenu(SOArchitecture_Utility.EVENT_LISTENER_SUBMENU + "Item")]
	public sealed class ItemGameEventListener : BaseGameEventListener<Item, ItemGameEvent, ItemUnityEvent>
	{
	}
}