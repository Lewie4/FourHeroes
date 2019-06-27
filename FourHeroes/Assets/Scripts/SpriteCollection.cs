using System;
using System.Collections.Generic;
using UnityEngine;

public class SpriteCollection : MonoBehaviour
{
    //TODO:Switch to Addressable Asset System?

    public static SpriteCollection Instance;

    public void Awake()
    {
        SpriteCollection.Instance = this;
    }

    [Header("Body Parts")]
    public List<CosmeticSet> Head;
    public List<CosmeticSet> Ears;
    public List<CosmeticSet> Hair;
    public List<CosmeticSet> Eyebrows;
    public List<CosmeticSet> Eyes;
    public List<CosmeticSet> Mouth;
    public List<CosmeticSet> Beard;
    public List<CosmeticSet> Body;

    [Header("Equipment")]
    //public List<CosmeticSet> Glasses;
    //public List<CosmeticSet> Mask;
    //public List<CosmeticSet> Earrings;
    public List<ArmourSet> Armor;
    public List<CosmeticSet> Back;
    public List<CosmeticSet> MeleeWeapon1H;
    public List<CosmeticSet> MeleeWeapon2H;
    public List<CosmeticSet> MeleeWeaponTrail1H;
    public List<CosmeticSet> MeleeWeaponTrail2H;
    public List<CosmeticSet> Bow;
    public List<CosmeticSet> Shield;
    public List<CosmeticSet> Supplies;

    [Header("Service")]
    public bool UseTrailSprites = true;
    public bool DebugLogging;
}