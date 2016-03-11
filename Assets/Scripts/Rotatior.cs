using UnityEngine;
using System.Collections;

public class Rotatior : MonoBehaviour {
    public float angle = 5;
	
	void FixedUpdate () {
        transform.Rotate(Vector3.forward, angle * Time.deltaTime);
	}
}
