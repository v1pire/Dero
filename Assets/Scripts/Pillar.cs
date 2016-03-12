using UnityEngine;
using System.Collections;

public class Pillar : MonoBehaviour {
    int healthDamage = 50;
    public float angle = 5;

    void FixedUpdate()
    {
        transform.Rotate(Vector3.forward, angle * Time.deltaTime);
    }

	void OnCollisionStay2D(Collision2D coll) 
    {
		if (coll.gameObject.tag == "Player")coll.gameObject.GetComponent<PlayerController> ().HealthDamage (healthDamage);
	}
}
