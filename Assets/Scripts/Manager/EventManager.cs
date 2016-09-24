using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;


public enum EVENT
{
	InitializeInitialPawns,

	SelectPawn,
	UnselectPawn,

	AddedPawnToParty,

	ClearPawn,

	SpawnEnemyPawn,

	FightATurn
}

public delegate void EventCallback (EventDataModel data);

public static class EventManager
{
	readonly static Dictionary<EVENT, List<EventCallback>> callbackMap = new Dictionary<EVENT, List<EventCallback>> ();

	public static void AddEventListener (EVENT eventKey, EventCallback callback)
	{
		if (!callbackMap.ContainsKey (eventKey))
		{
			callbackMap.Add (eventKey, new List<EventCallback> ());
		}

		callbackMap [eventKey].Add (callback);
	}

	public static void RemoveEventListener (EVENT eventKey, EventCallback callback)
	{
		if (!callbackMap.ContainsKey (eventKey))
		{
			return;
		}

		if (!callbackMap [eventKey].Contains (callback))
		{
			return;
		}

		callbackMap [eventKey].Remove (callback);
	}

	public static void DispatchEvent (EVENT eventKey, EventDataModel argv = null)
	{
		if (!callbackMap.ContainsKey (eventKey))
		{
			return;
		}

		callbackMap [eventKey].ForEach ((callback) => callback (argv));
	}
}

public abstract class EventDataModel
{
}

public sealed class SelectEventDataModel : EventDataModel
{
	public Pawn Pawn;
}

public sealed class AddedToPartyEventDataModel : EventDataModel
{
	public Pawn Pawn;
}

public sealed class UnselectEventDataModel : EventDataModel
{
	public Pawn Pawn;
}

public sealed class InitPawnsEventDataModel : EventDataModel
{
	public List<Pawn> Pawns;
}

public sealed class SpawnEnemyPawnEventDataModel : EventDataModel
{
	public List<Pawn> Pawns;
}