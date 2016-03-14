using UnityEngine;
using System.Collections;

public class Switcher : MonoBehaviour, IUseble {
    bool isOn = false;
    public SpriteRenderer lamp;
    
    public bool GetState()//внешний
    {
        return isOn;
    }

    public void Use(params string[] args)//внешний
    {
        isOn = true;
        SetLampState();  
    }

    public void SetLampState()//общий
    {
        if (isOn == true) lamp.color = Color.green;
        else lamp.color = Color.red;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<PlayerController>().activeUsebleObject = this;
        }
    }

    void OnTriggerExit2D(Collider2D  other)
    {
        if (other.gameObject.tag == "Player") other.GetComponent<PlayerController>().activeUsebleObject = null;
    }

}
