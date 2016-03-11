using UnityEngine;
using System.Collections;

public class Actionator : MonoBehaviour {
    public enum ActionType
    { 
        OnEnterTrigger,
        OnPressTerminal
    }
    public ActionType actionType;
    public GameAction gameActionObject;
    public string[] args;

    void OnTrigger2DEnter()
    {
        if(actionType==ActionType.OnEnterTrigger)ActionTrigger();
    }

    void OnTrigger2DStay()
    {
       if(actionType==ActionType.OnPressTerminal && Input.GetKey(KeyCode.Space)) ActionTrigger();
    }

    void ActionTrigger()
    {
        gameActionObject.ActionStart(args);
    }

}

public interface GameAction 
{
     void ActionStart(params string[] args);

}
