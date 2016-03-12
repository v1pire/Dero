using UnityEngine;
using System.Collections;

public class Actionator : MonoBehaviour, IAction {
    
    public void ActionStart(params string[] args)
    {
        Debug.Log("пустое событие");//вывесьти в консоль
    }
}

public interface IAction
{
     void ActionStart(params string[] args);

}
