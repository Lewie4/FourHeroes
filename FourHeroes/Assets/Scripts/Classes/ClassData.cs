using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CharacterClass
{
    Warrior,
    Mage,
    Archer,
    Priest,
    Gladiator,
    Rogue,
    BeastMaster,
}

[CreateAssetMenu(fileName = "ClassData", menuName = "Classes/Data")]
public class ClassData : ScriptableObject
{
    [Header("Primary Stats")]
    [SerializeField] CharacterClass m_class;
    [SerializeField] float m_health;
    [SerializeField] float m_strength;
    [SerializeField] float m_dexterity;
    [SerializeField] float m_intelligence;
    [SerializeField] ClassStatMultiplier m_multiplier;

    [Header("Secondary Stats")]
    [SerializeField] float m_crit;
    [SerializeField] float m_dodge;
    [SerializeField] float m_block;
    [SerializeField] float m_attackSpeed;
}
