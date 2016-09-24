using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;


/// <summary>
/// Container for Selected Pawn prefabs
/// </summary>
public class SelectedPawns : MonoBehaviour
{
	List<SelectedPawn> SelectedPawnBoards;

	// Use this for initialization
	void Start ()
	{
		// Cache pawn boards
		SelectedPawnBoards = new List<SelectedPawn> ();
		var e = GetComponentsInChildren<SelectedPawn> ().GetEnumerator ();
		while (e.MoveNext ())
		{
			SelectedPawnBoards.Add ((SelectedPawn)e.Current);
		}

		EventManager.AddEventListener (EVENT.SelectPawn, OnSelectPawn);

	}

	void OnSelectPawn (EventDataModel data)
	{
		var targetData = (SelectEventDataModel)data;
		if (targetData == null)
		{
			return;
		}

		SelectedPawn cell = GetEmptyCell ();
		if (cell != null)
		{
			cell.SetPawnImage (targetData.Pawn);
			cell.HP.value = 1.0F;
			targetData.Pawn.PawnDef.HP = targetData.Pawn.PawnDef.MaxHP;

			AddedToPartyEventDataModel partyAddData = new AddedToPartyEventDataModel ();
			partyAddData.Pawn = targetData.Pawn;
			EventManager.DispatchEvent (EVENT.AddedPawnToParty, partyAddData);
		}
	}

	SelectedPawn GetEmptyCell ()
	{
		SelectedPawn result = null;

		SelectedPawnBoards.ForEach ((SelectedPawn cell) =>
		{
			if (result != null)
			{
				return;
			}

			if (cell.IsEmpty ())
			{
				result = cell;
				return;
			}
		});

		return result;
	}
}
