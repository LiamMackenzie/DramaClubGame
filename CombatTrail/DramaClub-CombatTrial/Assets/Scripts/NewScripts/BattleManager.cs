using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BattleState
{
    ROUND_START,
    CHOOSE_ACTIONS,
    CHOOSE_WAITING,
    RUN_ACTIONS,
    ROUND_END
}

public class BattleManager : MonoBehaviour
{
    public BattleCharacter[] characters;
    public BattleState state;
    public bool running = false;
    public GameObject alliesObject;
    public GameObject enemiesObject;

    private List<BattleAction> _actionsThisRound;
    private BattleCharacter[] allies;
    public BattleCharacter[] enemies;
    
    private int _currentCharacterIndex;


    // Start is called before the first frame update
    void Start()
    {
        characters = GetComponentsInChildren<BattleCharacter>();
        allies = alliesObject.GetComponentsInChildren<BattleCharacter>();
        enemies = enemiesObject.GetComponentsInChildren<BattleCharacter>();

        _actionsThisRound = new List<BattleAction>();
        Debug.Log("There are " + characters.Length + " characters");   
        state = BattleState.ROUND_START; 
        running = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!running)
            return;

        switch (state)
        {
            case BattleState.ROUND_START:
            {
                DoRoundStart();
                break;
            }
            case BattleState.CHOOSE_ACTIONS:
            {
                DoChooseActions();
                break;
            }
            case BattleState.CHOOSE_WAITING:
            {
                break;
            }
            case BattleState.RUN_ACTIONS:
            {
                DoRunActions();
                break;
            }
            case BattleState.ROUND_END:
            {
                DoRoundEnd();
                break;
            }
        }
        
    }

    public BattleCharacter[] GetAllies(BattleCharacter b)
    {
        if (System.Array.IndexOf(allies, b) != -1)
            return allies;
        else 
            return enemies;
    }
    public BattleCharacter[] GetEnemies(BattleCharacter b)
    {
        if (System.Array.IndexOf(allies, b) != -1)
            return enemies;
        else
            return allies;
    }

    public void SwitchStateTo(BattleState newstate)
    {
        //do any logic here based on state and newstate
        
        //if you were waiting and are moving to choose actions, then
        //tell the current character it's not their turn any more.
        //and move to the next character
        if (state == BattleState.CHOOSE_WAITING && newstate == BattleState.CHOOSE_ACTIONS)
        {
            characters[_currentCharacterIndex].SetTurn(this, false); //not their turn any more.
            _currentCharacterIndex+= 1;
        }

        if (state == BattleState.CHOOSE_ACTIONS && newstate == BattleState.RUN_ACTIONS)
        {
            SortActionsThisRound();
        }

        state = newstate;
    }

    public void DoRoundStart()
    {
        Debug.Log("Starting Round");
        _currentCharacterIndex = 0;
        _actionsThisRound.Clear();
        SwitchStateTo(BattleState.CHOOSE_ACTIONS);
    }

    public void DoChooseActions()
    {
        Debug.Log("Choosing Actions");
        
        if (_currentCharacterIndex < characters.Length)
        {
            //tell the current character it is their turn to choose
            characters[_currentCharacterIndex].SetTurn(this, true);
            //now wait until they choose
            SwitchStateTo(BattleState.CHOOSE_WAITING);
        }
        else
        {
            //everybody has had their turn
            SwitchStateTo(BattleState.RUN_ACTIONS);
        }
        
    }

    public void DoRunActions()
    {
        Debug.Log("Running Actions - there are " + _actionsThisRound.Count + " actions to run");
        foreach (BattleAction action in _actionsThisRound)
        {
            action.DoAction();
        }
        SwitchStateTo(BattleState.ROUND_END);
    }

    public void DoRoundEnd()
    {
        Debug.Log("Round End");
        running = false;
    }

    public void AddAction(BattleAction a)
    {
        
        _actionsThisRound.Add(a);
        //they've chosen, go back to letting more characters choose actions
        SwitchStateTo(BattleState.CHOOSE_ACTIONS);
        
    }

    private void SortActionsThisRound()
    {
        _actionsThisRound.Sort(BattleAction.CompareActions);
        //now, the list should be sorted by speed.
    }
}
