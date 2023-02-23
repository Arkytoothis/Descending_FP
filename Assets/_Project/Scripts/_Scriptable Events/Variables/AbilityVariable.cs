using Descending.Abilities;
using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public class AbilityEvent : UnityEvent<Ability> { }

	[CreateAssetMenu(
	    fileName = "AbilityVariable.asset",
	    menuName = SOArchitecture_Utility.VARIABLE_SUBMENU + "Ability",
	    order = 120)]
	public class AbilityVariable : BaseVariable<Ability, AbilityEvent>
	{
	}
}