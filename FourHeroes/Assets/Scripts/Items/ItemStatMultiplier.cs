using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemStatMult", menuName = "Items/Multiplier")]
public class ItemStatMultiplier : ScriptableObject
{
    public StatMultiplier statMultiplier1;
    public StatMultiplier statMultiplier2;
    public StatMultiplier statMultiplier3;
    public StatMultiplier statMultiplier4;
}
