using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public int PlayerHealth = 100;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void HealthDamage(int Damage){
		PlayerHealth -= Damage;
		if (PlayerHealth <= 0) Application.LoadLevel (Application.loadedLevel);
	}
}
