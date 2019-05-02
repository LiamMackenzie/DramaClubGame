using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class BaseEnemy 
{
    public string name;

    public enum Affinity
    {
        Wind,
        Electric,
        Ice,
        Water,
        Fire,
        Earth,
        Light,
        Nature,
        Void,
        Mind
    }

    public Affinity EnemyClub;


    public int baseHP;
    public int currentHP;
    public int baseMP;
    public int currentMP;

   public int STR;// Basic attacks: STR - DEF = Damage
   public int MAG;// Magic attacks: MAG - RES = Damage
   public int SKILL;// Crit chance + Accuracy: Attacker SKILL - Enemy LUCK = Crit chance. Attacker SKILL - (Enemy SPD/2) = Hit chance
   public int SPD;// Turn order + Evasion
   public int LCK;// Crit evasion + Drop rates + Consumable efficiency
   public int DEF;//  Basic defense
   public int RES;//   Magic defense
}
