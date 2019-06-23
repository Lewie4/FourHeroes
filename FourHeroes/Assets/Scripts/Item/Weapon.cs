using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "CWeapon1", menuName = "Items/Weapon")]
public class Weapon : BaseItem
{
    [Header("Weapon Specific")]
    [SerializeField] WeaponType weaponType;
    [SerializeField] float range;
}
