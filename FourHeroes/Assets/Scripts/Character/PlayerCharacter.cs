using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : BaseCharacter
{
    [System.Serializable]
    public class PlayerCharacterData
    {
        public int characterLevel;
        public int characterExperience;
        public CharacterClass characterClass;
        public ItemInstance weapon;
        public ItemInstance armour;
        public ItemInstance amulet;
        public ItemInstance relic;
        public ClassData classData;
    }

    [SerializeField] private PlayerCharacterData m_characterData;

    protected override void SetupStats()
    {
        ClearStats();
        AddClassStats();
        AddItemStats(m_characterData.amulet);
        AddItemStats(m_characterData.armour);
        AddItemStats(m_characterData.relic);
        AddItemStats(m_characterData.weapon);
    }

    private void AddClassStats()
    {
        if (m_characterData.classData != null)
        {
            m_totalStats.attackSpeed += m_characterData.classData.attackSpeed.Evaluate(m_characterData.characterLevel);
            m_totalStats.block += m_characterData.classData.block.Evaluate(m_characterData.characterLevel);
            m_totalStats.crit += m_characterData.classData.crit.Evaluate(m_characterData.characterLevel);
            m_totalStats.dexterity += m_characterData.classData.dexterity.Evaluate(m_characterData.characterLevel);
            m_totalStats.dodge += m_characterData.classData.dodge.Evaluate(m_characterData.characterLevel);
            m_totalStats.health += m_characterData.classData.health.Evaluate(m_characterData.characterLevel);
            m_totalStats.intelligence += m_characterData.classData.intelligence.Evaluate(m_characterData.characterLevel);
            m_totalStats.strength += m_characterData.classData.strength.Evaluate(m_characterData.characterLevel);
        }
    }

    private void AddItemStats(ItemInstance item)
    {
        //TODO: Check I have the right level for the item
        if (item != null && item.itemStats != null)
        {
            AddStat(item.stat1, item.itemStats.statMultiplier.statMultiplier1, item.ilvl);
            AddStat(item.stat2, item.itemStats.statMultiplier.statMultiplier2, item.ilvl);
            AddStat(item.stat3, item.itemStats.statMultiplier.statMultiplier3, item.ilvl);
            AddStat(item.stat4, item.itemStats.statMultiplier.statMultiplier4, item.ilvl);
        }
    }

    private void AddStat(Stat itemStat, StatMultiplier statMult, int ilvl)
    {
        switch (itemStat)
        {
            case Stat.AttackSpeed:
                {
                    m_totalStats.attackSpeed -= statMult.attackSpeedMult;
                    break;
                }
            case Stat.Block:
                {
                    m_totalStats.block += statMult.blockMult;
                    break;
                }
            case Stat.Crit:
                {
                    m_totalStats.crit += statMult.critMult;
                    break;
                }
            case Stat.Dexterity:
                {
                    m_totalStats.dexterity += statMult.dexterityMult * ilvl;
                    break;
                }
            case Stat.Dodge:
                {
                    m_totalStats.dodge += statMult.dodgeMult;
                    break;
                }
            case Stat.Health:
                {
                    m_totalStats.health += statMult.healthMult * ilvl;
                    break;
                }
            case Stat.Intelligence:
                {
                    m_totalStats.intelligence += statMult.intelligenceMult * ilvl;
                    break;
                }
            case Stat.Strength:
                {
                    m_totalStats.strength += statMult.strengthMult * ilvl;
                    break;
                }
            default:
                {
                    break;
                }
        }
    }

    protected override float CalculateDamage()
    {
        float dexDamage = m_currentStats.dexterity * m_characterData.classData.multiplier.statMultiplier.dexterityMult;
        float intDamage = m_currentStats.intelligence * m_characterData.classData.multiplier.statMultiplier.intelligenceMult;
        float strDamage = m_currentStats.strength * m_characterData.classData.multiplier.statMultiplier.strengthMult;

        //TODO:Crit chance

        return dexDamage + intDamage + strDamage;
    }
}
