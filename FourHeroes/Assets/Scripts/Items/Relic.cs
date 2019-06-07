using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "CRelic1", menuName = "Items/Relic")]
public class Relic : BaseItem
{
    [Header("Relic Specific")]
    [SerializeField] CharacterClass relicClass;
}
