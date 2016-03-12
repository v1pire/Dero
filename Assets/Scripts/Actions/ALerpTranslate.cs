using UnityEngine;
using System.Collections;

public class ALerpTranslate : MonoBehaviour, IAction
{
    public Transform Operand;//обьект манипуляций
    Vector2 startPos;
    public Vector2 needPos;
    bool isNeedMove = false;

    public void ActionStart(params string[] args)
    {
        if (isNeedMove == false)
        {
            isNeedMove = true;
        }
    }

    void FixedUpdate()
    {
        if (isNeedMove == true)
        {
            Operand.transform.position = Vector2.Lerp(Operand.transform.position, needPos, Time.deltaTime * 2);
        }
    }
}
