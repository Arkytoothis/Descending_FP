using Descending.Abilities;
using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class AbilityUnityEvent : UnityEvent<Ability>
	{
	}
}