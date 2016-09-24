using UnityEngine;
using System.Collections;

public class FightButton : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
		EventManager.DispatchEvent (EVENT.FightATurn, null);
	}
}
