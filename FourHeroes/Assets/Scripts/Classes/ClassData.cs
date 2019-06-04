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
    [SerializeField] AnimationCurve m_health;
    [SerializeField] AnimationCurve m_strength;
    [SerializeField] AnimationCurve m_dexterity;
    [SerializeField] AnimationCurve m_intelligence;
    [SerializeField] ClassStatMultiplier m_multiplier;

    [Header("Secondary Stats")]
    [SerializeField] AnimationCurve m_crit;
    [SerializeField] AnimationCurve m_dodge;
    [SerializeField] AnimationCurve m_block;
    [SerializeField] AnimationCurve m_attackSpeed;
}
