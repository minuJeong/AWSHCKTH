using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;


public class Game : MonoBehaviour
{
	public PawnsControl PawnControl;

	readonly List<DataControl> DataControls = new List<DataControl> ();

	// Use this for initialization
	void Start ()
	{
		DataControls.Add (PawnControl);

		DataControls.ForEach ((control) => control.Init ());

		StartCoroutine (DelayCall (LazyInit));
	}

	/// <summary>
	/// Continue next frame
	/// </summary>
	IEnumerator DelayCall (Action callback)
	{
		yield return null;

		callback ();
	}

	void LazyInit ()
	{
		DataControls.ForEach (
			(control) => control.LazyInit ()
		);
	}
}
