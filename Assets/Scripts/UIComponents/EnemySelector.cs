using UnityEngine;
using System.Collections.Generic;

public class EnemySelector : MonoBehaviour
{
	List<SelectedPawn> SelectedPawnBoards;

	void Start ()
	{
		// Cache pawn boards
		SelectedPawnBoards = new List<SelectedPawn> ();
		var e = GetComponentsInChildren<SelectedPawn> ().GetEnumerator ();
		while (e.MoveNext ())
		{
			SelectedPawnBoards.Add ((SelectedPawn)e.Current);
		}

		EventManager.AddEventListener (EVENT.SpawnEnemyPawn, OnSpawnEnemyPawns);
	}

	void OnSpawnEnemyPawns (EventDataModel data)
	{
		SpawnEnemyPawnEventDataModel targetData = (SpawnEnemyPawnEventDataModel)data;

		if (targetData == null)
		{
			return;
		}

		targetData.Pawns.ForEach ((pawn) =>
		{
			SelectedPawn cell = GetEmptyCell ();
			if (cell != null)
			{
				cell.SetPawnImage (pawn);
			}
		});
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
