using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Button in Pawn Pool
/// </summary>
public class PawnButton : MonoBehaviour
{
	public Pawn Pawn;

	public Image PawnImage;
	public Text PawnName;


	public void Init (Pawn pawn)
	{
		Pawn = pawn;

		PawnImage.sprite = pawn.PawnDef.PawnImage;
		PawnName.text = pawn.PawnDef.PawnName;

		// add callback to button click
		Button thisButton = GetComponent<Button> ();
		if (thisButton == null)
		{
			return;
		}

		thisButton.onClick.AddListener (OnClickPawn);
	}

	void OnClickPawn ()
	{
		SelectEventDataModel data = new SelectEventDataModel ();
		data.Pawn = Pawn;


		EventCallback AddedToPartyCallback;
		AddedToPartyCallback = (onAddedData) =>
		{
			AddedToPartyEventDataModel targetData = (AddedToPartyEventDataModel)onAddedData;
			if (targetData == null)
			{
				return;
			}

			if (targetData.Pawn.PawnID == Pawn.PawnID)
			{
				Destroy (gameObject);

				EventManager.RemoveEventListener (EVENT.AddedPawnToParty, AddedToPartyCallback);
			}
		};

		EventManager.AddEventListener (EVENT.AddedPawnToParty, AddedToPartyCallback);

		EventManager.DispatchEvent (EVENT.SelectPawn, data);
	}
}
