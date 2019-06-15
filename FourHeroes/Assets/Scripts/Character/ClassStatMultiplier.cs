using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StatMultiplier
{
    public float healthMult;
    public float strengthMult;
    public float dexterityMult;
    public float intelligenceMult;

    public float critMult;
    public float dodgeMult;
    public float blockMult;
    public float attackSpeedMult;
}

[CreateAssetMenu(fileName = "ClassStatMult", menuName = "Characters/ClassStatMultiplier")]
public class ClassStatMultiplier : ScriptableObject
{
    public StatMultiplier statMultiplier;
}
