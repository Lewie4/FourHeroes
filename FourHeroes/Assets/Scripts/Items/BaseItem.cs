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
    public Stat m_stat;
    public float m_multiplier;
}


public class BaseItem : ScriptableObject
{
    [SerializeField] protected ItemType m_itemType;
    [SerializeField] protected ItemQuality m_quality;

    [Header("Item Stats")]
    [SerializeField] protected ItemStat m_stat1;
    [SerializeField] protected ItemStat m_stat2;
    [SerializeField] protected ItemStat m_stat3;
    [SerializeField] protected ItemStat m_stat4;
    [SerializeField] protected int m_specialAbility;    //TODO: Replace with special ability (Mainly for Relics)

}
