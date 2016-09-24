using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// Selected Pawn preview prefab control
/// </summary>
public class SelectedPawn : MonoBehaviour
{
	public Image PawnImage;
	public Slider HP;

	Button thisButton;

	Pawn pawn;


	// Use this for initialization
	void Start ()
	{
		// Confirm editor setups
		Debug.Assert (PawnImage != null, "Pawn Image should be selected in Editor");
		Debug.Assert (HP != null, "HP Bar should be selected");

		// init
		ClearPawnImage ();

		thisButton = GetComponent<Button> ();
		thisButton.onClick.AddListener (OnClick);
	}

	public void SetPawnImage (Pawn pawn)
	{
		this.pawn = pawn;
		pawn.SelectedPawnUI = this;

		PawnImage.sprite = pawn.PawnDef.PawnImage;
		PawnImage.color = new Color (1, 1, 1, 1.0F);

		HP.gameObject.SetActive (true);
	}

	public void ClearPawnImage ()
	{
		if (pawn != null)
		{
			pawn.SelectedPawnUI = null;
		}

		PawnImage.sprite = null;
		PawnImage.color = new Color (1, 1, 1, 0.0F);

		HP.gameObject.SetActive (false);
	}

	public bool IsEmpty ()
	{
		return PawnImage.sprite == null;
	}


	void OnClick ()
	{
		ClearPawnImage ();
		var data = new UnselectEventDataModel ();
		data.Pawn = pawn;
		EventManager.DispatchEvent (EVENT.UnselectPawn, data);
	}
}
