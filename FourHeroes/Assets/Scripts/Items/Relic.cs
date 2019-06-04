using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CRelic1", menuName = "Items/Relic")]
public class Relic : BaseItem
{
    [Header("Relic Specific")]
    [SerializeField] CharacterClass relicClass;
}
