using UnityEngine;
using System.Collections;

public class Switcher : MonoBehaviour, IUseble {
    public IAction action;
    public SpriteRenderer lamp;
    public GameObject OnUSeAction;//тут хрень

    public void Use(params string[] args)
    { 
        action.ActionStart();
        SetLampState(true);
        
    }

    void SetLampState(bool isGreenLight)
    {
        if (isGreenLight == true) lamp.color = Color.green;
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

    void Start()
    {
        action = OnUSeAction.GetComponent<IAction>();//тут хрень
    }
}
