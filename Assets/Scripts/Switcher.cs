using UnityEngine;
using System.Collections;

public class Switcher : MonoBehaviour {
    public GameObject pillar;
    public SpriteRenderer lamp;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            lamp.color = Color.green;
            TranslateObj();
        }
    }

    void TranslateObj()
    {
        pillar = GameObject.Find("Pillar (1)");
        pillar.transform.position =  new Vector3(6.69f,0,0);
    }

    void OnTriggerExit2D(Collider2D  other)
    {
        if (other.gameObject.tag == "Player") lamp.color = Color.red;
    }
}
