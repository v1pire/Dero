using UnityEngine;
using System.Collections;

public class ASetNewPos : MonoBehaviour, IAction {
    public Transform Operand;//обьект манипуляций
    Vector2 startPos;
    public Vector2 needPos;
    bool isNeedMove = true;

    public void ActionStart(params string[] args)
    {
        if (isNeedMove == true)
        {
            Operand.transform.position = needPos;
            isNeedMove = false;
        }
    }
}
