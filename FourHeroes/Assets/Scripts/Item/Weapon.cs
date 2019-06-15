using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType
{
    Sword,
    Daggers,
    Staff,
    Bow,
}

[System.Serializable]
[CreateAssetMenu(fileName = "CWeapon1", menuName = "Items/Weapon")]
public class Weapon : BaseItem
{
    [Header("Weapon Specific")]
    [SerializeField] WeaponType weaponType;
}
