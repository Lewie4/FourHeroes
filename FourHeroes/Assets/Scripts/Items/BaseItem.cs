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
    public ItemQuality quality;
    public ItemStatMultiplier statMultiplier;
    public StatPossibilities statPossibilities;
}
