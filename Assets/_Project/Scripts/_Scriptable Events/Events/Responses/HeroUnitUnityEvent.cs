using Descending.Units;
using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class HeroUnitUnityEvent : UnityEvent<HeroUnit>
	{
	}
}