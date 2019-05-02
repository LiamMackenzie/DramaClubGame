using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroStateMachine : MonoBehaviour
{
    public BaseHero hero;

    public enum TurnState
    {
        IDLE,
        ACTION_SELECTION,
        ACTION,
        DEAD
    }
    
    public TurnState CurrentState;
    void Start()
    {
        CurrentState = TurnState.IDLE;
    }

    
    void Update()
    {
        switch(CurrentState)
        {
            case(TurnState.IDLE):
            
            break;

            case(TurnState.ACTION_SELECTION):

            break;

            case(TurnState.ACTION):

            break;

            case(TurnState.DEAD):

            break;


        }
    
    }

    /* public ChangeState(TurnState destState)
    {

        CurrentState = destState;
    }*/
}
