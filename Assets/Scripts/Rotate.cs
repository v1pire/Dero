using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {
	int healthDamage;


	// Use this for initialization
	void Start () {
		healthDamage = 50;
	}
	
	// Update is called once per frame
	void Update () {
			
	}

	void OnCollisionStay2D(Collision2D coll) {
		if (coll.gameObject.tag == "Player")
			coll.gameObject.GetComponent<PlayerController> ().HealthDamage (healthDamage);
	}
		
	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Player")
			coll.gameObject.GetComponent<PlayerController> ().HealthDamage (healthDamage);
	} 
}
