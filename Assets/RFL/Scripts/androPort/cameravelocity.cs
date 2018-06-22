using UnityEngine;
using System.Collections;

public class cameravelocity : MonoBehaviour {


	private float speed = 12.0f;
	
	void Update () {
		
		GetComponent<Rigidbody2D>().velocity = new Vector3(speed,0,0);
	}
	

	void receiveSpeed (float theSpeed) {
		speed = theSpeed;
	}
}
