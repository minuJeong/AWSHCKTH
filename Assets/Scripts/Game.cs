using UnityEngine;
using Facebook.Unity;


public class Game : MonoBehaviour
{
	const string URL = "https://crlv4910ld.execute-api.ap-northeast-2.amazonaws.com/prod/SimpleMobileBackendExample";

	// Used for sign in cognito credential
	public string IDENTITY_POOL_ID;

	void Start ()
	{
		StartLogInFB ();
	}

	void StartLogInFB ()
	{
		FB.Init (() =>
		{
			Debug.Log ("Initializing FB..");
			FB.LogInWithReadPermissions (new string[]{ "email" }, (ILoginResult result) =>
			{
				Debug.Log (result.RawResult);
				Debug.Log (result.AccessToken);

				OnFBLoggedIn ();
			});
		}, null, null);
	}

	void OnFBLoggedIn ()
	{
		StartLoginAWS ();
	}

	void StartLoginAWS ()
	{
		AWSWrapped.SignIn ();
		InvokeTestLambda ();
	}

	void InvokeTestLambda ()
	{
		AWSWrapped.InvokeLambda ("sampleLambda", "{}");
	}
}
