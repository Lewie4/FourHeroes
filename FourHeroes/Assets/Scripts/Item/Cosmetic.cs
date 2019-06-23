using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "Cosmetic", menuName = "Cosmetic")]
public class Cosmetic : ScriptableObject
{
    public string cosmeticName;

    public List<Sprite> sprites;
}
