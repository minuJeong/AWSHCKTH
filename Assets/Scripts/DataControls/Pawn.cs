using System;
using UnityEngine;
using UnityEngine.UI;


public enum PawnSide
{
	PlayerSide,
	EnemySide
}

public class Pawn
{
	readonly Guid _pawnID = new Guid ();

	public Guid PawnID
	{
		get
		{
			return _pawnID;
		}
	}

	public PawnClassesDef PawnDef;
	public SelectedPawn SelectedPawnUI;

	public PawnSide pawnSide;


	// Prevent instantiating a pawn
	private Pawn (PawnClassesDef defData, PawnSide side)
	{
		PawnDef = defData;
		pawnSide = side;
	}

	public static Pawn GeneratePawn (PawnClassesDef defData, PawnSide side)
	{
		return new Pawn (defData, side);
	}

	public void Die ()
	{
		// Die
	}

	/// <summary>
	/// Generate a random pawn data
	/// </summary>
	/// <returns>The random pawn.</returns>
	public static Pawn GetRandomPawn (PawnSide side)
	{
		Func<string> GetName = () =>
		{
			string[] availables = new string[] {
				"Fighter",
				"Mage",
				"Hunter",
				"Orc",
				"Goblin"
			};
			int count = availables.Length;
			int resultIndex = UnityEngine.Random.Range (0, count);
			return availables [resultIndex];
		};

		Func<string, PawnClassesDef> GetDef = 
			(string name) => Resources.Load<PawnClassesDef> ("Mercs/Data/" + name);


		return GeneratePawn (
			GetDef (GetName ()),
			side
		);
	}
}
