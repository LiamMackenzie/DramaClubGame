using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleCharacter : MonoBehaviour
{
    public string characterName = "Name";
    private List<BattleAction> _actions;
    private bool _isMyTurn, _choosingTarget;
    private int _actionSelection; //list index of chosen action
    private BattleManager _manager;
    private BattleCharacter[] _potentialTargets;
    public Stats stats;
    public Button targetButton;
    public Text targetText;
    public GameObject characterMenuRoot;
    private int _targetIndex; //what 'choice number' the battlemanager thinks I am.

    // Start is called before the first frame update
    void Start()
    {
        //get all battle action components on me.
        BattleAction[] actionlist = GetComponentsInChildren<BattleAction>();
        _actions = new List<BattleAction>(actionlist); //put them in the list.
        _isMyTurn = false;

        if (targetText != null)
        {
            targetText.text = characterName;
        }
        ShowCharacterMenu(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (_isMyTurn)
        {
            DoMyTurn();
        }
    }

    public void SetTurn( bool turn)
    {
        stats.CHealth = stats.MaxHealth;
        stats.CMana = stats.MaxMana;
        _isMyTurn = turn;
        _actionSelection = -1;
        _choosingTarget = false;
        _potentialTargets = null;
        if (turn)
        {
            GetComponent<Renderer>().material.color = Color.red;
            PrintAvailableActions();
        }
        else
        {
            GetComponent<Renderer>().material.color = Color.white;
        }
    }

    void PrintAvailableActions()
    {
        Debug.Log("It is " + characterName + "'s turn");
        int count = 1;
        foreach (BattleAction action in _actions)
        {
            Debug.Log(count.ToString() + ": " + action.actionName);
            count++;
        }
    }

    void PrintTargets(BattleCharacter[] characters)
    {
        int count = 1;
        foreach (BattleCharacter bc in characters)
        {
            Debug.Log(count.ToString() + ": " + bc.characterName);
            count +=1 ;
        }
    }

    void PrintAvailableTargets()
    {
        BattleAction selectedAction = _actions[_actionSelection];
        if (selectedAction.actionTargetType == BattleActionTargetingType.SINGLE_ALLY_TARGET)
        {
            _potentialTargets = _manager.GetAllies(this);
            
        }
        else if (selectedAction.actionTargetType == BattleActionTargetingType.SINGLE_ENEMY_TARGET)
        {
            _potentialTargets = _manager.GetEnemies(this);
            
        }
        Debug.Log("Choose your target");
        PrintTargets(_potentialTargets);
        
    }

    void DoMyTurn()
    {
        if (!_choosingTarget)
        {
            ChooseAction();   
        }
        else
        {
            //choosing the target
            ChooseTarget();
        }
    }

    public void SetManager(BattleManager m)
    {
        _manager = m;
    }

    public void ShowCharacterMenu(bool shouldShow)
    {
        if (characterMenuRoot != null)
        {
            characterMenuRoot.SetActive(shouldShow);
        }
    }

   public void ChooseAction(int actionSelection=-1)
    {
        _actionSelection = actionSelection;
        
        //choose an action (actionselection is an INDEX!)
        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            
            _actionSelection = 0;
        }
        else if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            
            _actionSelection = 1;
        }
        else if (Input.GetKeyUp(KeyCode.Alpha3))
        {
            
            _actionSelection = 2;
        }
        else if (Input.GetKeyUp(KeyCode.Alpha4))
        {
            
            _actionSelection = 3;
        }
        
        //add more cases as necessary

        if (_actionSelection != -1 && _actionSelection < _actions.Count)
        {
            BattleActionTargetingType batt = _actions[_actionSelection].actionTargetType;
            Debug.Log("Action targetting type was " + batt);
            if (batt != BattleActionTargetingType.SELF && 
                batt != BattleActionTargetingType.ENEMY_PARTY &&
                batt != BattleActionTargetingType.ALLY_PARTY )
            {
                _manager.ChooseTargetMode(true, batt);
                //we need to choose a target
                _choosingTarget = true;
                PrintAvailableTargets();
            }
            else
            {
                //we can queue without a target
                QueueAction();
            }
        }
        else if (_actionSelection > -1 )
        {
            Debug.Log("There's no action in that slot");
        }
    }

    public void ChooseTarget(int choice=0)
    {
        //choose a target
        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            choice = 1;
        }
        else if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            choice = 2;
        }
        else if (Input.GetKeyUp(KeyCode.Alpha3))
        {
            choice = 3;
        }
        else if(Input.GetKeyUp(KeyCode.Alpha4))
        {
            choice = 4;
        }

        if (choice != 0) //0 means no choice
        {
            Debug.Log("The Choice was: " + choice);
            if (choice <= _potentialTargets.Length)
            {
                _actions[_actionSelection].target = _potentialTargets[choice-1];
                QueueAction();
                _manager.ChooseTargetMode(false);
            }
            else
            {
                Debug.Log("Not a valid target");
            }
        }
    }

    void QueueAction()
    {
       
        BattleAction theAction = _actions[_actionSelection];
        theAction.source = this;
        _manager.AddAction(theAction);
        
    }

    public void YourIndexIs(int index)
    {
        _targetIndex = index;
    }

    public void OnClickedAsTarget()
    {
        _manager.OnMouseChooseCurrentCharactersTarget(_targetIndex);
    }
    
}


