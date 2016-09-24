using UnityEngine;
using System;
using GooglePlayGames.BasicApi;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;


public static class GooglePlusWrapped
{
	
	public static void SignIn (Action<string> tokenCallback)
	{
		PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder ()
			.Build ();
		PlayGamesPlatform.InitializeInstance (config);
		PlayGamesPlatform.DebugLogEnabled = true;
		PlayGamesPlatform.Activate ();


		Action<bool> GoogleLoginCallback = (bool success) =>
		{
			Debug.Log ("CALLBACK");
			if (success)
			{
				tokenCallback (PlayGamesPlatform.Instance.GetToken ());
				Debug.Log ("Google Logged In");
			}
			else
			{
				Debug.Log ("Failed to log in google");
			}
		};

		Social.localUser.Authenticate (GoogleLoginCallback);
	}
}
