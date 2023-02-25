using Descending.Encounters;
using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class EncounterReference : BaseReference<Encounter, EncounterVariable>
	{
	    public EncounterReference() : base() { }
	    public EncounterReference(Encounter value) : base(value) { }
	}
}