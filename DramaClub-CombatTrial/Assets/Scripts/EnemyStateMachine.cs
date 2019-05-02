using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : MonoBehaviour
{
    private BattleManager BM;
    public BaseEnemy enemy;

    public enum TurnState
    {
        IDLE,
        ACTION_SELECTION,
        ACTION,
        DEAD
    }
    
    public TurnState CurrentState;
    //game object
    private Vector2 startpoint;
    void Start()
    {
        CurrentState = TurnState.IDLE;
        BM = GameObject.Find("BattleManager").GetComponent<BattleManager> ();
        startpoint = transform.position;
    }

    
    void Update()
    {
        switch(CurrentState)
        {
            case(TurnState.IDLE):

            break;

            case(TurnState.ACTION_SELECTION):
                ChooseAction();
                
            break;

            case(TurnState.ACTION):

            break;

            case(TurnState.DEAD):

            break;


        }

    }

    void ChooseAction()
    {

        TurnHandler myAttack = new TurnHandler ();
        myAttack.Attacker = enemy.name;
        myAttack.AttackersGameObject = this.gameObject;
        myAttack.AttackersTarget = BM.HerosInBattle[Random.Range(0,BM.HerosInBattle.Count)];
        BM.Collect_Actions(myAttack);
    }
}

