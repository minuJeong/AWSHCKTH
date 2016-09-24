using UnityEngine;
using System.Collections;

public class PawnsPool : MonoBehaviour
{
	const string RESTING_PAWN_UI_PREFAB_PATH = "Prefabs/UIPrefabs/PawnButton_Base";
	GameObject RestingPawnPrefab = null;

	// Use this for initialization
	void Start ()
	{
		EventManager.AddEventListener (EVENT.InitializeInitialPawns, OnInitPawns);
	}

	void OnInitPawns (EventDataModel data)
	{
		InitPawnsEventDataModel targetData = (InitPawnsEventDataModel)data;
		if (targetData == null)
		{
			return;
		}

		if (RestingPawnPrefab == null)
		{
			RestingPawnPrefab = Resources.Load<GameObject> (RESTING_PAWN_UI_PREFAB_PATH);
		}

		targetData.Pawns.ForEach ((Pawn pawn) =>
		{
			GameObject newUIPrefab = Instantiate<GameObject> (RestingPawnPrefab);
			newUIPrefab.transform.SetParent (transform);
			newUIPrefab.transform.localScale = Vector3.one;

			PawnButton pawnButton = newUIPrefab.GetComponent<PawnButton> ();
			pawnButton.Init (pawn);
		});
	}
}
