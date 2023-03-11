using Descending.Gui;
using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public class HeroDamageTextEvent : UnityEvent<HeroDamageText> { }

	[CreateAssetMenu(
	    fileName = "HeroDamageTextVariable.asset",
	    menuName = SOArchitecture_Utility.VARIABLE_SUBMENU + "HeroDamageText",
	    order = 120)]
	public class HeroDamageTextVariable : BaseVariable<HeroDamageText, HeroDamageTextEvent>
	{
	}
}