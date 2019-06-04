using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    [System.Serializable]
    public class HeroStats
    {
        public float health;
        public float strength;
        public float dexterity;
        public float intelligence;
        public float crit;
        public float dodge;
        public float block;
        public float attackSpeed;
    }

    [SerializeField] ClassData m_class;
    [SerializeField] int m_weaponIlvl;
    [SerializeField] Weapon m_weapon;
    [SerializeField] int m_armourIlvl;
    [SerializeField] Armour m_armour;
    [SerializeField] int m_amuletIlvl;
    [SerializeField] Amulet m_amulet;
    [SerializeField] int m_relicIlvl;
    [SerializeField] Relic m_relic;

    [SerializeField] private HeroStats m_currentStats;

    private void Start()
    {
        SetupStats();
    }

    private void ClearStats()
    {
        m_currentStats = new HeroStats();
    }

    public void SetupStats()
    {
        ClearStats();
        AddItemStats(m_amulet, m_amuletIlvl);
        AddItemStats(m_armour, m_armourIlvl);
        AddItemStats(m_relic, m_relicIlvl);
        AddItemStats(m_weapon, m_weaponIlvl);
    }

    public void AddItemStats(BaseItem item, int ilvl)
    {
        if (item != null)
        {
            AddStat(item.stat1, ilvl);
            AddStat(item.stat2, ilvl);
            AddStat(item.stat3, ilvl);
            AddStat(item.stat4, ilvl);
        }
    }

    public void AddStat(ItemStat itemStat, int ilvl)
    {
        float statPoints = (itemStat.multiplier * ilvl);
        switch (itemStat.stat)
        {
            case Stat.AttackSpeed:
                {
                    m_currentStats.attackSpeed += statPoints;
                    break;
                }
            case Stat.Block:
                {
                    m_currentStats.block += statPoints;
                    break;
                }
            case Stat.Crit:
                {
                    m_currentStats.crit += statPoints;
                    break;
                }
            case Stat.Dexterity:
                {
                    m_currentStats.dexterity += statPoints;
                    break;
                }
            case Stat.Dodge:
                {
                    m_currentStats.dodge += statPoints;
                    break;
                }
            case Stat.Health:
                {
                    m_currentStats.health += statPoints;
                    break;
                }
            case Stat.Intelligence:
                {
                    m_currentStats.intelligence += statPoints;
                    break;
                }
            case Stat.Strength:
                {
                    m_currentStats.strength += statPoints;
                    break;
                }
            default:
                {
                    break;
                }
        }
    }

    private void Attack()
    {
        Debug.Log("Attack");
    }
}