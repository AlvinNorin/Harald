using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Player_Controller : NetworkBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	/*void Update () {
		if (isLocalPlayer)
		if (Input.GetKey(KeyCode.W)) {
			transform.Translate(0, 0, 4 * Time.deltaTime);
		}
		if (Input.GetKey(KeyCode.A)) {
			transform.Translate(-(4 * Time.deltaTime), 0, 0);
		}
		if (Input.GetKey(KeyCode.S)) {
			transform.Translate(0, 0, -(4 * Time.deltaTime));
		}
		if (Input.GetKey(KeyCode.D)) {
			transform.Translate(4 * Time.deltaTime, 0, 0);
    }
  }*/
}
