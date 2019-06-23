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
    public List<Cosmetic> Head;
    public List<Cosmetic> Ears;
    public List<Cosmetic> Hair;
    public List<Cosmetic> Eyebrows;
    public List<Cosmetic> Eyes;
    public List<Cosmetic> Mouth;
    public List<Cosmetic> Beard;
    public List<Cosmetic> Body;

    [Header("Equipment")]
    public List<Cosmetic> Helmet;
    public List<Cosmetic> Glasses;
    public List<Cosmetic> Mask;
    public List<Cosmetic> Earrings;
    public List<Cosmetic> Armor;
    public List<Cosmetic> Cape;
    public List<Cosmetic> Back;
    public List<Cosmetic> MeleeWeapon1H;
    public List<Cosmetic> MeleeWeapon2H;
    public List<Cosmetic> MeleeWeaponTrail1H;
    public List<Cosmetic> MeleeWeaponTrail2H;
    public List<Cosmetic> Bow;
    public List<Cosmetic> Shield;
    public List<Cosmetic> Supplies;

    [Header("Service")]
    public bool UseTrailSprites = true;
    public bool DebugLogging;
}