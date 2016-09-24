using System.Text;

using UnityEngine;

using Amazon;
using Amazon.CognitoSync.SyncManager;
using Amazon.CognitoIdentity;
using Amazon.Lambda;
using Amazon.Lambda.Model;


public static class AWSWrapped
{
	const string URL = "https://crlv4910ld.execute-api.ap-northeast-2.amazonaws.com/prod/SimpleMobileBackendExample";

	const string IDENTITY_POOL_ID = "ap-northeast-1:6b910612-d2c0-4d10-bfcf-70343402a895";

	static CognitoAWSCredentials _credentials;

	static CognitoAWSCredentials Credentials
	{
		get
		{
			if (_credentials == null)
			{
				_credentials = new CognitoAWSCredentials (
					IDENTITY_POOL_ID,
					RegionEndpoint.APNortheast1
				);
			}

			return _credentials;
		}
	}

	static AmazonLambdaClient _client = null;

	static AmazonLambdaClient LambdaClient
	{
		get
		{
			if (_client == null)
			{
				_client = new AmazonLambdaClient (Credentials, RegionEndpoint.APNortheast1);
			}
			return _client;
		}
	}

	public static void InvokeLambda (string func, string eventText)
	{
		LambdaClient.InvokeAsync (
			new InvokeRequest () { 
				FunctionName = func,
				Payload = eventText
			}, (response) =>
		{
			Log ("PARSED");
			Log (Encoding.ASCII.GetString (response.Response.Payload.ToArray ()));
		}
		);
	}


	public static CognitoSyncManager SignIn ()
	{
		return new CognitoSyncManager (Credentials, RegionEndpoint.APNortheast1);
	}



	static void Log (object context)
	{
		Log (context.ToString ());
	}

	static void Log (string context)
	{
		Debug.Log (context);
	}
}
