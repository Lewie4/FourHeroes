using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Weapon,
    Armour,
    Amulet,
    Relic
}

public enum ItemQuality
{
    Common,
    Rare,
    Epic,
    Legendary
}

public enum Stat
{
    None,
    Health,
    Strength,
    Dexterity,
    Intelligence,
    Crit,
    Dodge,
    Block,
    AttackSpeed
}

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

[System.Serializable]
public class BaseItem : ScriptableObject
{
    public ItemType itemType;
    public ItemStatMultiplier statMultiplier;

    [Header("Item Stats")]
    public StatPossibility stat1;
    public StatPossibility stat2;
    public StatPossibility stat3;
    public StatPossibility stat4;
    public int specialAbility;   //TODO: Replace with special ability (Mainly for Relics)

}
