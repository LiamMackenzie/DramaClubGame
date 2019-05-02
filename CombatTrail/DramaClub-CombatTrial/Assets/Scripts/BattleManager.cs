using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    
  
    public enum PerformAction
    {
      WAIT,
      TAKEACTION,
      PERFORMACTION
    }

    public PerformAction battleStates;

    public List<TurnHandler> PerformList = new List<TurnHandler> ();

    public List<GameObject> HerosInBattle = new List<GameObject> ();
    public List<GameObject> EnemiesInBattle = new List<GameObject> ();


    void Start()
    {
      battleStates = PerformAction.WAIT;

      GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
      foreach (GameObject e in enemies)
      {
            EnemiesInBattle.Add(e);    
      }
    GameObject[] Heros = GameObject.FindGameObjectsWithTag("Hero");
      foreach (GameObject h in Heros)
      {
            HerosInBattle.Add(h);    
      }

    }

    void Update()
    {
        SwitchStatesTest();
        Debug.Log(battleStates);
        switch(battleStates)
        {
            case(PerformAction.WAIT):

            break;

            case(PerformAction.TAKEACTION):

            break;

            case(PerformAction.PERFORMACTION):

            break;

        }
       
    }

     void SwitchStatesTest()
    {
        if (Input.GetKeyDown("space"))
        {
            if(battleStates == PerformAction.WAIT)
            {
                battleStates = PerformAction.TAKEACTION;
            }
            else if (battleStates == PerformAction.TAKEACTION)
            {
                battleStates = PerformAction.PERFORMACTION;                    
            }
            else if ( battleStates == PerformAction.PERFORMACTION)
            {
                 battleStates = PerformAction.WAIT;
            }
          
        }
    }

    public void Collect_Actions (TurnHandler input)
    {
        PerformList.Add(input);
    }
    


}
