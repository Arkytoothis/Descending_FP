using Descending.Equipment;
using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public class ItemEvent : UnityEvent<Item> { }

	[CreateAssetMenu(
	    fileName = "ItemVariable.asset",
	    menuName = SOArchitecture_Utility.VARIABLE_SUBMENU + "Item",
	    order = 120)]
	public class ItemVariable : BaseVariable<Item, ItemEvent>
	{
	}
}