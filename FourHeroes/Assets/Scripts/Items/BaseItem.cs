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
public class ItemStat
{
    public Stat stat;
    public float value;
}


public class BaseItem : ScriptableObject
{
    public ItemType itemType;
    public ItemQuality quality;

    [Header("Item Stats")]
    public ItemStat stat1;
    public ItemStat stat2;
    public ItemStat stat3;
    public ItemStat stat4;
    public int specialAbility;   //TODO: Replace with special ability (Mainly for Relics)

}
