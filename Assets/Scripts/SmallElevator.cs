using UnityEngine;
using System.Collections;

public class SmallElevator : MonoBehaviour {
    public Vector2 startPos;
    public Vector2 needPos;
    bool isPlayerStay = true;

    void Start()
    {
        startPos = transform.position;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            transform.position = Vector2.Lerp(transform.position, needPos, Time.deltaTime );
            isPlayerStay = true;
        }
        else
            isPlayerStay = false;    
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")isPlayerStay = false;            
    }

    void Update()
    {
        if(isPlayerStay==false)transform.position = Vector2.Lerp(transform.position, startPos, Time.deltaTime);
    }
}
