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
public class BaseItem : ScriptableObject
{
    public ItemType itemType;
    public ItemQuality itemQuality;

    [Header("Item Stats")]
    public StatMultiplier stat1;
    public StatMultiplier stat2;
    public StatMultiplier stat3;
    public StatMultiplier stat4;
    public int specialAbility;   //TODO: Replace with special ability (Mainly for Relics)

}
