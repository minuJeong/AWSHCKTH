using System;
using UnityEngine;

#if UNITY_EDITOR
using System.IO;
using UnityEditor;
#endif


public class PawnClassesDef : ScriptableObject
{
	public string PawnName;
	public Sprite PawnImage;

	public int MaxHP;
	public int HP;

	public int Attack;
	public int Def;

	public Pawn Owner;
}


#if UNITY_EDITOR
[CustomEditor (typeof(PawnClassesDef))]
public class PawnClassesDefEditor : Editor
{
	const string DIR_PATH = "Assets/Resources/Mercs/Data";
	const string BASE_PATH = DIR_PATH + "/{0}.asset";

	[MenuItem ("Tools/Add New Pawn Class")]
	public static void AddNewPawnDef ()
	{
		if (!Directory.Exists (DIR_PATH))
		{
			Directory.CreateDirectory (DIR_PATH);
		}

		AssetDatabase.CreateAsset (
			ScriptableObject.CreateInstance<PawnClassesDef> (),
			string.Format (BASE_PATH, "NewPawnData"));
		
	}

	public override void OnInspectorGUI ()
	{
		base.OnInspectorGUI ();
	}
}
#endif
