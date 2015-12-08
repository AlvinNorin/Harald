using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class NetworkManager_State : NetworkBehaviour {

	public bool StartHost = false;
	public static string PlayerName = "Harald";
	public static bool isConnected = false;
	

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	public void s_StartHost() {
		gameObject.GetComponent<NetworkManager>().StartHost();
		ClientScene.Ready(gameObject.GetComponent<NetworkManager>().client.connection);
		if (ClientScene.localPlayers.Count == 0)
			ClientScene.AddPlayer(0);
	}
	
	public void s_SetIP(string ip) {
		gameObject.GetComponent<NetworkManager>().networkAddress = ip;
		Debug.Log(ip);
	}
	
	public void s_StartClient() {
		gameObject.GetComponent<NetworkManager>().StartClient();
		StartCoroutine(s_WaitForNetworkServerActive());
		StartCoroutine(s_WaitForConnectionToBeCompleted());
	}
	
	public void s_StopClient() {
		gameObject.GetComponent<NetworkManager>().StopClient();
		gameObject.GetComponent<NetworkManager>().StopAllCoroutines();
		Network.Disconnect();
		MasterServer.UnregisterHost();
		NetworkServer.Reset();
		//NetworkTransport.Receive();
  	}
	
	IEnumerator s_WaitForNetworkServerActive() {
		Debug.Log(NetworkClient.active + "*" + ClientScene.ready);
		//while (!NetworkServer.active) {
			Debug.Log(NetworkClient.active + "-" + ClientScene.ready);
			yield return null;
		//}
		Debug.Log(NetworkClient.active + " " + ClientScene.ready);
		ClientScene.Ready(gameObject.GetComponent<NetworkManager>().client.connection);
		if (ClientScene.localPlayers.Count == 0)
			ClientScene.AddPlayer(0);
		
  	}
	
	IEnumerator s_WaitForConnectionToBeCompleted() {
		while (GameObject.FindWithTag("isLocalPlayer") == null) {
			yield return null;
		}
		isConnected = true;
  	}
  
  	public void s_SetPlayerName(string name) {
		PlayerName = name;
  	}
	
	void Update () {
		//if (gameObject.GetComponent<UI>())
		//gameObject.GetComponent<NetworkManager>().StartHost();
	}
}
