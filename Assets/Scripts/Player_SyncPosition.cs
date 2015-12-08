using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Player_SyncPosition : NetworkBehaviour {
	
	[SyncVar] private Vector3 syncPos;
	[SyncVar] private string syncName;
	[SerializeField] Transform myTransform;
	[SerializeField] float lerpRate = 15;

	void Update() {
		ControllPosition();
		if (isLocalPlayer) {
			gameObject.tag = "isLocalPlayer";
			GameObject.FindWithTag("isLocalPlayer").gameObject.transform.GetChild(3).gameObject.tag = "isLocalPlayerName";
		} else Name_Set.name = syncName;
  	}

	void FixedUpdate() {
		TransmitPosition ();
		TransmitName();
		LerpPosition();
	}
	
	void LerpPosition() {
		if (!isLocalPlayer) {
			myTransform.position = Vector3.Lerp(myTransform.position, syncPos, Time.deltaTime * lerpRate);
		}
	}
	
	[Command]
	void CmdProvidePositionToServer(Vector3 pos) {
		syncPos = pos;
  	}
  	
	[Command]
	void CmdProvideNameToServer(string _name) {
		syncName = _name;
	}
  
 	[ClientCallback]
	void TransmitPosition() {
		if (isLocalPlayer) {
			CmdProvidePositionToServer(myTransform.position);
		}
	}
	
	[ClientCallback]
	void TransmitName() {
		if (isLocalPlayer) {
			CmdProvideNameToServer(NetworkManager_State.PlayerName);
		}
	}
	
	public bool isGrounded;
	void OnTriggerEnter() {
		//if (refPlayerController) {
			isGrounded=true;
		//}
	}
	void OnTriggerStay() {
		//if (refPlayerController) {
			isGrounded=true;
    	//}
	}
	void OnTriggerExit() {
		//if (refPlayerController) {
			isGrounded=false;
    	//}
    }
 	void ControllPosition() {
		if (isLocalPlayer) {
			float playerSpeed = 3;
			if (Input.GetKey(KeyCode.W)) {
				transform.Translate(0, 0, 5*Time.deltaTime);
			}
			if (Input.GetKey(KeyCode.A)) {
				transform.Translate(-(5*Time.deltaTime), 0, 0);
			}
			if (Input.GetKey(KeyCode.S)) {
				transform.Translate(0, 0, -(5*Time.deltaTime));
			}
			if (Input.GetKey(KeyCode.D)) {
				transform.Translate(5*Time.deltaTime, 0, 0);
			}
			if (Input.GetKeyDown(KeyCode.Space)) {
				if (isGrounded) {
					GetComponent<Rigidbody>().AddForce(Vector3.up * 5, ForceMode.Impulse);
					isGrounded = false;
				}
          /*Vector3 rayOrigin = transform.position;
				rayOrigin.y += GetComponent<BoxCollider>().bounds.extents.y;
				float rayDistance = GetComponent<BoxCollider>().bounds.extents.y + 0.1f;
				Ray ray = new Ray();
				ray.origin = rayOrigin;
				ray.direction = Vector3.down;
				if (Physics.Raycast(ray, rayDistance, 1 << 8)) {
					GetComponent<Rigidbody>().AddForce(Vector3.up * 4, ForceMode.VelocityChange);
				}*/
      		}
    }
  }
  
}
