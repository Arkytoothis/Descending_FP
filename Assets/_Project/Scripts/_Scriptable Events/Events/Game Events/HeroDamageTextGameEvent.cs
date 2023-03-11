using Descending.Gui;
using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	[CreateAssetMenu(
	    fileName = "HeroDamageTextGameEvent.asset",
	    menuName = SOArchitecture_Utility.GAME_EVENT + "HeroDamageText",
	    order = 120)]
	public sealed class HeroDamageTextGameEvent : GameEventBase<HeroDamageText>
	{
	}
}