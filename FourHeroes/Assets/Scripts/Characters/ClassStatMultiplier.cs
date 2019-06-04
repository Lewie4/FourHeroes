using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ClassStatMult", menuName = "Classes/Multiplier")]
public class ClassStatMultiplier : ScriptableObject
{
    public float healthMult;
    public float strengthMult;
    public float dexterityMult;
    public float intelligenceMult;
}
