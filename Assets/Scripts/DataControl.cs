using System;

using UnityEngine;


[Serializable]
public abstract class DataControl : MonoBehaviour
{
	public virtual void Init ()
	{
	}

	public virtual void LazyInit ()
	{
	}
}

