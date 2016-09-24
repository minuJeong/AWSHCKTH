using System;
using System.Collections.Generic;
using System.Text;

using UnityEngine;

using Amazon;
using Amazon.Runtime;
using Amazon.CognitoSync.SyncManager;
using Amazon.CognitoIdentity;
using Amazon.Lambda;
using Amazon.Lambda.Model;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;


public static class AWSWrapped
{
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

	static CognitoSyncManager _syncManager;

	static CognitoSyncManager SyncManager
	{
		get
		{
			if (_syncManager == null)
			{
				_syncManager = new CognitoSyncManager (Credentials, RegionEndpoint.APNortheast1);
			}

			return _syncManager;
		}
	}


	static AmazonLambdaClient _lambdaClient = null;

	static AmazonLambdaClient LambdaClient
	{
		get
		{
			if (_lambdaClient == null)
			{
				_lambdaClient = new AmazonLambdaClient (Credentials, RegionEndpoint.APNortheast1);
			}
			return _lambdaClient;
		}
	}


	static AmazonDynamoDBClient _dbClient;

	static AmazonDynamoDBClient DBClient
	{
		get
		{
			if (_dbClient == null)
			{
				_dbClient = new AmazonDynamoDBClient (Credentials, RegionEndpoint.APNortheast1);
			}
			return _dbClient;
		}
	}


	public static void LogIn ()
	{
		Credentials.AddLogin ("ap-northeast-1_fTu1pFFfH", "2o59uianljchia00t383mjgmte");
		Array.ForEach (
			Credentials.CurrentLoginProviders,
			(item) =>
			{
				Debug.Log (item);
			}
		);

		Credentials.GetCredentialsAsync (
			(credentials) =>
			{
				Debug.Log (credentials.Response.AccessKey);
				Debug.Log (credentials.Response.SecretKey);
				Debug.Log (credentials.Response.Token);
			}, null
		);
	}

	public static void DB ()
	{
		Dictionary<string, AttributeValue> argvs = new Dictionary<string, AttributeValue> () {
			{ "ID", new AttributeValue ("1") }
		};

		GetItemRequest request = new GetItemRequest ("AssetReference", argvs);
		DBClient.GetItemAsync (request, (AmazonServiceResult<GetItemRequest, GetItemResponse> result) =>
		{
			Debug.Log (result.Request.Key);
			Debug.Log (result.Response.Item.Count);
		}, null);
	}


	public static void InvokeLambda (string func, string eventText)
	{
		LambdaClient.InvokeAsync (
			new InvokeRequest () { 
				FunctionName = func,
				Payload = eventText
			},
			(response) =>
			{
				if (response.Exception != null)
				{
					Log ("EXCEPTION", response.Exception);
				}
				else
				{
					Log ("PARSED", Encoding.ASCII.GetString (response.Response.Payload.ToArray ()));
				}
			}
		);
	}

	static void Log (params object[] context)
	{
		List<string> strings = new List<string> ();
		Array.ForEach (context, (item) => strings.Add (item.ToString ()));
		Log (string.Join (", ", strings.ToArray ()));
	}

	static void Log (object context)
	{
		Debug.Log (context.ToString ());
	}
}
