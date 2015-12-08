using UnityEngine;
using System.Collections;

public class MenuEvents : MonoBehaviour {

	public bool InGameMenuActive = false;
	
	[SerializeField]
	Camera SceneCamera;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (InGameMenuActive) {
			SceneCamera.gameObject.SetActive(true);
			//GameObject.FindGameObjectWithTag("isLocalPlayer").name = "gg";
			GameObject.Find ("Menu").gameObject.transform.GetChild(1).gameObject.transform.GetChild(2).gameObject.SetActive(true);
			Debug.Log("Menu");
		} else {
			GameObject.Find ("Menu").gameObject.transform.GetChild(1).gameObject.transform.GetChild(2).gameObject.SetActive(false);
		}
		if (Input.GetKeyUp(KeyCode.Escape)) {
			if (InGameMenuActive) {
				SetInGameMenuActive(true);
			} else {
				SetInGameMenuActive(false);
			}
		}
		if (GameObject.FindWithTag("isLocalPlayer") == null && NetworkManager_State.isConnected) {
			Debug.Log("0");
			SceneCamera.gameObject.SetActive(true);
			GameObject.Find ("Menu").gameObject.transform.GetChild(1).gameObject.transform.GetChild(1).gameObject.SetActive(false);
			GameObject.Find ("Menu").gameObject.transform.GetChild(1).gameObject.transform.GetChild(2).gameObject.SetActive(false);
			GameObject.Find ("Menu").gameObject.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.SetActive(true);
			NetworkManager_State.isConnected = false;
		}
	}
	
	void OnDisconnectedFromServer(NetworkDisconnection info) {
		if (Network.isServer)
			Debug.Log("0");
		else
			if (info == NetworkDisconnection.LostConnection)
				Debug.Log("1");
			else
				Debug.Log("2");
		SceneCamera.gameObject.SetActive(true);
		GameObject.Find ("Menu").gameObject.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.SetActive(true);
	}
	
	public void SetInGameMenuActive(bool value) {
		if (value) {
			InGameMenuActive = false;
			SceneCamera.gameObject.SetActive(false);
		} else {
			InGameMenuActive = true;
			GameObject.Find ("Menu").gameObject.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.SetActive(false);
			GameObject.Find ("Menu").gameObject.transform.GetChild(1).gameObject.transform.GetChild(1).gameObject.SetActive(false);
		}
	}
}
