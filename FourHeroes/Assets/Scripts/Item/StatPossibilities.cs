using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StatPossibility
{
    public bool health;
    public bool strength;
    public bool dexterity;
    public bool intelligence;

    public bool crit;
    public bool dodge;
    public bool block;
    public bool attackSpeed;
}

[CreateAssetMenu(fileName = "StatPossibilities1", menuName = "Items/Stat Possibilities")]
public class StatPossibilities : ScriptableObject
{
    public StatPossibility stat1;
    public StatPossibility stat2;
    public StatPossibility stat3;
    public StatPossibility stat4;
}
