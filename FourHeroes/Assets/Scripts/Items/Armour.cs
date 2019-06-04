using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ArmourType
{
    Cloth,
    Leather,
    Plate,
}

[CreateAssetMenu(fileName = "CArmour1", menuName = "Items/Armour")]
public class Armour : BaseItem
{
    [Header("Armour Specific")]
    [SerializeField] ArmourType m_weaponType;
}
