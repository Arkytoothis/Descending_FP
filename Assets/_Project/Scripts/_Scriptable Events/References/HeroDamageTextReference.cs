using Descending.Gui;
using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class HeroDamageTextReference : BaseReference<HeroDamageText, HeroDamageTextVariable>
	{
	    public HeroDamageTextReference() : base() { }
	    public HeroDamageTextReference(HeroDamageText value) : base(value) { }
	}
}