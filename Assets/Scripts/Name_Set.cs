using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Name_Set : NetworkBehaviour {

	public static string name;

	// Use this for initialization
	void Start () {
		//GetComponent<TextMesh>().text = NetworkManager_State.PlayerName;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (gameObject.tag == "isLocalPlayerName") {
			GetComponent<TextMesh>().text = NetworkManager_State.PlayerName;
		}
		if (gameObject.tag != "isLocalPlayerName") {
			GetComponent<TextMesh>().text = name;
		}
	}
}
