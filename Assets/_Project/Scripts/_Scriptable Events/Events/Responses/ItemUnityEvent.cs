using Descending.Equipment;
using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class ItemUnityEvent : UnityEvent<Item>
	{
	}
}