using UnityEngine;
using System.Collections;

public class AutoDestroy : MonoBehaviour {
    public float timeToDestroy = 5;
	
	void Start () 
    {
        Destroy(gameObject, timeToDestroy);
	}
}
