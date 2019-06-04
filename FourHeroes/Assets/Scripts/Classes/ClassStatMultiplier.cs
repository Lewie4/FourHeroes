using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ClassStatMult", menuName = "Classes/Multiplier")]
public class ClassStatMultiplier : ScriptableObject
{
    [SerializeField] float healthMult;
    [SerializeField] float strengthMult;
    [SerializeField] float dexterityMult;
    [SerializeField] float intelligenceMult;
}
