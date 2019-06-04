using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ClassStatMult", menuName = "Classes/Multiplier")]
public class ClassStatMultiplier : ScriptableObject
{
    [SerializeField] float m_healthMult;
    [SerializeField] float m_strengthMult;
    [SerializeField] float m_dexterityMult;
    [SerializeField] float m_intelligenceMult;
}
