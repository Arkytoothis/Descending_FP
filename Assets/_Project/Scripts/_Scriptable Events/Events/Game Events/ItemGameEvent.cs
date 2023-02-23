using Descending.Equipment;
using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	[CreateAssetMenu(
	    fileName = "ItemGameEvent.asset",
	    menuName = SOArchitecture_Utility.GAME_EVENT + "Item",
	    order = 120)]
	public sealed class ItemGameEvent : GameEventBase<Item>
	{
	}
}