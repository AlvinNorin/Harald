using UnityEngine;
using System.Collections;

public class Mouse : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position.Set(Input.mousePosition.x, 0, 0);
	}
}
