using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "CosmeticSet", menuName = "Cosmetics/Cosmetic Set")]
public class CosmeticSet : ScriptableObject
{
    public string cosmeticName;

    public List<Sprite> sprites;
}
