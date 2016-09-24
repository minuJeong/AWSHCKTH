using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

using Facebook.Unity;


public class Home : MonoBehaviour
{
	const string URL = "https://crlv4910ld.execute-api.ap-northeast-2.amazonaws.com/prod/SimpleMobileBackendExample";

	void Start ()
	{
		// StartLoginGooglePlus ();
		// StartLoginAWS ();

		StartGame ();
	}

	void StartGame ()
	{
		SceneManager.LoadScene ("Game");
	}

	void StartLoginGooglePlus ()
	{
		GooglePlusWrapped.SignIn (OnLoggedInGoogle);
	}

	void OnLoggedInGoogle (string token)
	{
		Debug.Log (token);
	}

	void StartLoginAWS ()
	{
		// AWSWrapped.DB ();
		// AWSWrapped.LogIn ();
		// AWSWrapped.InvokeLambda ("HelloLambda", "{\"a\":\"1\"}");
	}
}
