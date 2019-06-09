﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HeroData
{
    public int characterLevel;
    public int characterExperience;
    public string className;
    public ItemInstance weapon;
    public ItemInstance armour;
    public ItemInstance amulet;
    public ItemInstance relic;

    public int groupSlot; // 0-3 for 4 slots, -1 for not in group

    private ClassData characterClass;

    public ClassData CharacterStats
    {
        get
        {
            if (characterClass == null)
            {
                characterClass = ((ClassDatabase)Resources.Load("ClassDatabase")).GetActual(className);
            }

            return characterClass;
        }
    }
}

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

        public HeroStats()
        {
        }

        public HeroStats(HeroStats stats)
        {
            health = stats.health;
            strength = stats.strength;
            dexterity = stats.dexterity;
            intelligence = stats.intelligence;
            crit = stats.crit;
            dodge = stats.dodge;
            block = stats.block;
            attackSpeed = stats.attackSpeed;
        }
    }

    [SerializeField] private HeroData m_heroData;

    //Everything below is only shown for debugging
    [SerializeField] protected HeroStats m_currentStats;    //Max current stats 
    [SerializeField] protected HeroStats m_combatStats;     //Stats to be used in combat

    //Combat
    bool m_isAlive = true;
    int m_target;

    [SerializeField] protected float m_timeSinceLastAttack;


    private void Start()
    {
        //Heroes.Instance.AddHero(m_heroData);
        SetupStats();
    }

    private void ClearStats()
    {
        m_currentStats = new HeroStats();
    }

    public void SetupStats()
    {
        ClearStats();
        AddClassStats();
        AddItemStats(m_heroData.amulet);
        AddItemStats(m_heroData.armour);
        AddItemStats(m_heroData.relic);
        AddItemStats(m_heroData.weapon);
    }

    private void AddClassStats()
    {
        if (m_heroData.CharacterStats != null)
        {
            m_currentStats.attackSpeed += m_heroData.CharacterStats.attackSpeed.Evaluate(m_heroData.characterLevel);
            m_currentStats.block += m_heroData.CharacterStats.block.Evaluate(m_heroData.characterLevel);
            m_currentStats.crit += m_heroData.CharacterStats.crit.Evaluate(m_heroData.characterLevel);
            m_currentStats.dexterity += m_heroData.CharacterStats.dexterity.Evaluate(m_heroData.characterLevel);
            m_currentStats.dodge += m_heroData.CharacterStats.dodge.Evaluate(m_heroData.characterLevel);
            m_currentStats.health += m_heroData.CharacterStats.health.Evaluate(m_heroData.characterLevel);
            m_currentStats.intelligence += m_heroData.CharacterStats.intelligence.Evaluate(m_heroData.characterLevel);
            m_currentStats.strength += m_heroData.CharacterStats.strength.Evaluate(m_heroData.characterLevel);
        }
    }

    private void AddItemStats(ItemInstance item)
    {
        //TODO: Check I have the right level for the item
        if (item != null && item.ItemStats != null && !string.IsNullOrEmpty(item.itemName))
        {
            AddStat(item.stat1, item.ItemStats.statMultiplier.statMultiplier1, item.ilvl);
            AddStat(item.stat2, item.ItemStats.statMultiplier.statMultiplier2, item.ilvl);
            AddStat(item.stat3, item.ItemStats.statMultiplier.statMultiplier3, item.ilvl);
            AddStat(item.stat4, item.ItemStats.statMultiplier.statMultiplier4, item.ilvl);
        }
    }

    public void SetupCombatStats()
    {
        m_combatStats = new HeroStats(m_currentStats);
    }

    private void AddStat(Stat itemStat, StatMultiplier statMult, int ilvl)
    {
        switch (itemStat)
        {
            case Stat.AttackSpeed:
                {
                    m_currentStats.attackSpeed -= statMult.attackSpeedMult;
                    break;
                }
            case Stat.Block:
                {
                    m_currentStats.block += statMult.blockMult;
                    break;
                }
            case Stat.Crit:
                {
                    m_currentStats.crit += statMult.critMult;
                    break;
                }
            case Stat.Dexterity:
                {
                    m_currentStats.dexterity += statMult.dexterityMult * ilvl;
                    break;
                }
            case Stat.Dodge:
                {
                    m_currentStats.dodge += statMult.dodgeMult;
                    break;
                }
            case Stat.Health:
                {
                    m_currentStats.health += statMult.healthMult * ilvl;
                    break;
                }
            case Stat.Intelligence:
                {
                    m_currentStats.intelligence += statMult.intelligenceMult * ilvl;
                    break;
                }
            case Stat.Strength:
                {
                    m_currentStats.strength += statMult.strengthMult * ilvl;
                    break;
                }
            default:
                {
                    break;
                }
        }
    }

    public HeroData GetHeroData()
    {
        return m_heroData;
    }

    public ClassData GetCharacterClassData()
    {
        return m_heroData.CharacterStats;
    }

    public void SetTarget(int target)
    {
        m_target = target;
    }

    public int GetTarget()
    {
        return m_target;
    }

    public float TryAttack()
    {
        if (m_isAlive)
        {
            m_timeSinceLastAttack += Time.deltaTime;

            if (CheckCanAttack())
            {
                m_timeSinceLastAttack -= m_currentStats.attackSpeed; //Keep any leftover time to not punish bad devices
                float dexDamage = m_currentStats.dexterity * m_heroData.CharacterStats.multiplier.statMultiplier.dexterityMult;
                float intDamage = m_currentStats.intelligence * m_heroData.CharacterStats.multiplier.statMultiplier.intelligenceMult;
                float strDamage = m_currentStats.strength * m_heroData.CharacterStats.multiplier.statMultiplier.strengthMult;

                //TODO:Crit chance

                float totalDamage = dexDamage + intDamage + strDamage; //TODO: Crit damage

                Debug.Log(gameObject.name + " did " + totalDamage + " damage to enemy" + m_target);

                return totalDamage;
            }
        }
        return 0;
    }

    private bool CheckCanAttack()
    {
        if (m_timeSinceLastAttack > m_currentStats.attackSpeed)
        {
            return true;
        }
        return false;
    }

    public void TakeDamage(float damage)
    {
        m_combatStats.health -= damage;

        if (m_combatStats.health <= 0)
        {
            m_combatStats.health = 0;
            Die();
        }
    }

    private void Die()
    {
        m_isAlive = false;

        Debug.Log("<color=red>" + gameObject.name + " has died!</color>");
    }

    public bool CheckAlive()
    {
        return m_isAlive;
    }

    public float GetHealth()
    {
        return m_combatStats.health;
    }


#if UNITY_EDITOR
    [ContextMenu("Kill Hero")]
    public void DebugKillHero()
    {
        TakeDamage(m_currentStats.health);
    }

    [ContextMenu("Save Gear To Inventory")]
    public void SaveGearToInventory()
    {
        Inventory.Instance.InsertItem(m_heroData.amulet);
        Inventory.Instance.InsertItem(m_heroData.armour);
        Inventory.Instance.InsertItem(m_heroData.relic);
        Inventory.Instance.InsertItem(m_heroData.weapon);
    }
#endif
}