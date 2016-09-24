using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

using DG.Tweening;


[Serializable]
public class PawnsControl : DataControl
{
	readonly List<Pawn> SelectedPawns = new List<Pawn> ();
	readonly List<Pawn> PawnPool = new List<Pawn> ();
	readonly List<Pawn> EnemyPawns = new List<Pawn> ();

	const int PLATER_PAWN_POOL_COUNT = 20;

	const int ENEMY_SPAWN_COUNT_MIN = 1;
	const int ENEMY_SPAWN_COUNT_MAX = 4;

	public FightButton fightButton;


	public override void Init ()
	{
		EventManager.AddEventListener (EVENT.AddedPawnToParty, AddPawnToParty);
		EventManager.AddEventListener (EVENT.UnselectPawn, UnselectPawn);

		fightButton.GetComponent<Button> ().onClick.AddListener (OnClickFightButton);
	}

	public override void LazyInit ()
	{
		SpawnPlayerPawns ();

		InitPawnsEventDataModel data = new InitPawnsEventDataModel ();
		data.Pawns = PawnPool;
		EventManager.DispatchEvent (EVENT.InitializeInitialPawns, data);
	}


	void SpawnPlayerPawns ()
	{
		for (int i = 0; i < PLATER_PAWN_POOL_COUNT; i++)
		{
			PawnPool.Add (
				Pawn.GetRandomPawn (PawnSide.PlayerSide)
			);
		}
	}

	void SpawnEnemies ()
	{
		List<Pawn> spawnedEnemyPawns = new List<Pawn> ();

		int range = UnityEngine.Random.Range (
			            ENEMY_SPAWN_COUNT_MIN, ENEMY_SPAWN_COUNT_MAX);
		
		for (int i = 0; i < range; i++)
		{
			Pawn newEnemyPawn = Pawn.GetRandomPawn (PawnSide.EnemySide);
			EnemyPawns.Add (newEnemyPawn);
			spawnedEnemyPawns.Add (newEnemyPawn);
		}

		SpawnEnemyPawnEventDataModel data = new SpawnEnemyPawnEventDataModel ();
		data.Pawns = spawnedEnemyPawns;
		EventManager.DispatchEvent (EVENT.SpawnEnemyPawn, data);
	}


	IEnumerator FightATurn ()
	{
		fightButton.gameObject.SetActive (false);

		if (EnemyPawns.Count == 0)
		{
			SpawnEnemies ();
		}
		else
		{

			int playerPawnCount = 0;
			int enemyPawnCount = 0;
			Func<bool> RefreshPawnsCount = () =>
			{
				playerPawnCount = SelectedPawns.Count;
				enemyPawnCount = EnemyPawns.Count;

				return playerPawnCount == 0 || enemyPawnCount == 0;
			};

			while (EnemyPawns.Count > 0 && SelectedPawns.Count > 0)
			{
				if (RefreshPawnsCount ())
				{
					break;
				}

				// Random player pawn attacks random enemy pawn
				int playerPawnAttackerIndex = UnityEngine.Random.Range (0, playerPawnCount);
				Pawn playerPawnAttacker = SelectedPawns [playerPawnAttackerIndex];
			
				int enemyPawnDefenderIndex = UnityEngine.Random.Range (0, enemyPawnCount);
				Pawn enemyPawnDefender = EnemyPawns [enemyPawnDefenderIndex];

				yield return Attack (playerPawnAttacker, enemyPawnDefender);

				yield return new WaitForSeconds (0.25F);


				if (RefreshPawnsCount ())
				{
					break;
				}

				// Random enemy pawn attacks random player pawn
				int enemyPawnAttackerIndex = UnityEngine.Random.Range (0, enemyPawnCount - 1);
				Pawn enemyPawnAttacker = EnemyPawns [enemyPawnAttackerIndex];

				int playerPawnDefenderIndex = UnityEngine.Random.Range (0, playerPawnCount - 1);
				Pawn playerPawnDefender = SelectedPawns [playerPawnDefenderIndex];

				yield return Attack (enemyPawnAttacker, playerPawnDefender);

				yield return new WaitForSeconds (0.25F);
			}
		}

		yield return new WaitForSeconds (0.25F);

		fightButton.gameObject.SetActive (true);
	}

	IEnumerator Attack (Pawn attacker, Pawn defender)
	{
		if (attacker.SelectedPawnUI != null)
		{
			attacker.SelectedPawnUI.transform
				.DOShakeScale (0.4F, 0.1F)
				.SetDelay (0.25F);
		}

		if (defender.SelectedPawnUI != null)
		{
			defender.SelectedPawnUI.transform
				.DOShakeScale (0.4F, 0.1F)
				.SetDelay (0.50F);
		}


		yield return new WaitForSeconds (0.50F);


		// is dead check
		defender.PawnDef.HP -= attacker.PawnDef.Attack - defender.PawnDef.Def;

		if (defender.SelectedPawnUI != null)
		{
			float HPBarValue = defender.PawnDef.HP / defender.PawnDef.MaxHP;
			defender.SelectedPawnUI.HP
				.DOValue (HPBarValue, 1.0F)
				.OnComplete (defender.SelectedPawnUI.ClearPawnImage);
		}

		yield return new WaitForSeconds (0.50F);

		if (defender.PawnDef.HP <= 0)
		{
			defender.PawnDef.HP = 0;

			defender.Die ();

			if (defender.SelectedPawnUI != null)
			{
				defender.SelectedPawnUI.ClearPawnImage ();
			}

			switch (defender.pawnSide)
			{
			case PawnSide.PlayerSide:
				Debug.Assert (SelectedPawns.Contains (defender));
				SelectedPawns.Remove (defender);
				break;

			case PawnSide.EnemySide:
				Debug.Assert (EnemyPawns.Contains (defender));
				EnemyPawns.Remove (defender);
				break;
			}
		}
	}

	void OnClickFightButton ()
	{
		StartCoroutine (FightATurn ());
	}


	void AddPawnToParty (EventDataModel data)
	{
		var targetData = (AddedToPartyEventDataModel)data;
		if (targetData == null)
		{
			return;
		}

		PawnPool.Remove (targetData.Pawn);
		SelectedPawns.Add (targetData.Pawn);
	}

	void UnselectPawn (EventDataModel data)
	{
		var targetData = (UnselectEventDataModel)data;
		if (targetData == null)
		{
			return;
		}

		PawnPool.Add (targetData.Pawn);
		SelectedPawns.Remove (targetData.Pawn);
	}
}
