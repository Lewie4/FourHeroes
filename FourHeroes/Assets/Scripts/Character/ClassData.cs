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

[CreateAssetMenu(fileName = "ClassData", menuName = "Characters/ClassData")]
public class ClassData : ScriptableObject
{
    [Header("Primary Stats")]
    public CharacterClass characterClass;
    public AnimationCurve health;
    public AnimationCurve strength;
    public AnimationCurve dexterity;
    public AnimationCurve intelligence;
    public ClassStatMultiplier multiplier;

    [Header("Secondary Stats")]
    public AnimationCurve crit;
    public AnimationCurve dodge;
    public AnimationCurve block;
    public AnimationCurve attackSpeed;
}
