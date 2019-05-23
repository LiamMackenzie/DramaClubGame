using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BattleActionTargetingType
{
    SINGLE_ALLY_TARGET,
    SINGLE_ENEMY_TARGET,
    SELF,
    ALLY_PARTY,
    ENEMY_PARTY
}
public enum BattleActionType
{
    Normal,
    Wind,
    Electricity,
    Ice,
    Water,
    Void,
    Mind,
    Fire,
    Earth,
    Light,
    Nature
}
public enum AttackType
{
    Physical,
    Magical,
    StatUP,
    StatDown
}


public class BattleAction : MonoBehaviour
{
    public string actionName = "Unknown";
    public float actionSpeed = 1.0f;
    public BattleCharacter source;
    public BattleCharacter target;
    public BattleActionType actionType;
    public AttackType attacktype;
    public BattleActionTargetingType actionTargetType;
    public int actionAmount;
    public Stats stats;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static int CompareActions(BattleAction a, BattleAction b)
    {
        // if a is higher than b, result is negative
        // if b is higher than a, result is positive
        // if equal, result is 0
        return (int)(b.Speed() - a.Speed());
    }

    public virtual void DoAction()
    {
        
        string output = source.characterName + " is doing " + actionName + " for " + actionAmount + " of " + actionType + " damage";
        //override me
        if (actionTargetType == BattleActionTargetingType.SINGLE_ENEMY_TARGET)
        {
            Damage();
            output += " on " + target.characterName + "." + target.characterName + " s health is now" + target.stats.CHealth + "/" + target.stats.MaxHealth;
        }
        else if (actionTargetType == BattleActionTargetingType.SINGLE_ALLY_TARGET)
        {
            Heal();
            output += " on " + target.characterName + "." + target.characterName + "s health is now" + target.stats.CHealth + "/" + target.stats.MaxHealth;
        }
        else if (actionTargetType == BattleActionTargetingType.SELF)
        {
            output += " on self.";
        }
        else if (actionTargetType == BattleActionTargetingType.ENEMY_PARTY)
        {
            
            output += " on enemy party";
        }
        else if (actionTargetType == BattleActionTargetingType.ALLY_PARTY)
        {
            output += " on ally party";
        }
        Debug.Log(output);
    }

    public float Speed()
    {
        return source.stats.baseSpeed + actionSpeed;
    }


    public float Damage()
    {
        target.stats.CHealth = target.stats.CHealth - actionAmount;

        return target.stats.CHealth;
    }
    public float Heal()
    {
        target.stats.CHealth = target.stats.CHealth + actionAmount;

        return target.stats.CHealth;
    }
   
    /* public void actionAmountCalculater()
    {
        if(attacktype == AttackType.Physical)
        {
            actionAmount = PhysicalDamageCalculater();

        }
        else if(attacktype == AttackType.Magical)
        {
            actionAmount = PhysicalDamageCalculater();
        }
    }

    public float MagicDamageCalculater()
    {
        return source.Magic + actionAmount;
    }
    public float PhysicalDamageCalculater()
    {
        return source.Strength + actionAmount;
    }*/
  
}
