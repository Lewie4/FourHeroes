using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ArmourType
{
    Cloth,
    Leather,
    Plate,
}

[System.Serializable]
[CreateAssetMenu(fileName = "CArmour1", menuName = "Items/Armour")]
public class Armour : BaseItem
{
    [Header("Armour Specific")]
    [SerializeField] ArmourType armourType;
}
