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
    [SerializeField] CharacterClass characterClass;
    [SerializeField] AnimationCurve health;
    [SerializeField] AnimationCurve strength;
    [SerializeField] AnimationCurve dexterity;
    [SerializeField] AnimationCurve intelligence;
    [SerializeField] ClassStatMultiplier multiplier;

    [Header("Secondary Stats")]
    [SerializeField] AnimationCurve crit;
    [SerializeField] AnimationCurve dodge;
    [SerializeField] AnimationCurve block;
    [SerializeField] AnimationCurve attackSpeed;
}
