using Descending.Equipment;
using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class ItemReference : BaseReference<Item, ItemVariable>
	{
	    public ItemReference() : base() { }
	    public ItemReference(Item value) : base(value) { }
	}
}