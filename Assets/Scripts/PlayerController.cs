using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    public IUseble activeUsebleObject;//тут обьект, с которым взаимодействеум

    public int PlayerHealth = 100;

    void UseObject()
    {
        if (activeUsebleObject != null) activeUsebleObject.Use();
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.E)) UseObject();//если нажата кнопка Е
    }
	
	public void HealthDamage(int Damage){
		PlayerHealth -= Damage;
        if (PlayerHealth <= 0) Death();
	}

    void Death()
    { 
    Application.LoadLevel (Application.loadedLevel);
    }
}
