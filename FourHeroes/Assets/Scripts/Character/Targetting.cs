using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "Targetting", menuName = "Characters/Targetting")]
public class Targetting : ScriptableObject
{
    public enum TargettingType
    {
        Closest,
        Furthest,
        LowestHealth,
        HighestHealth
    }

    [SerializeField] private TargettingType m_targettingType;

    private Vector2 m_currentPos;
    private Group m_oppositeGroup;

    public BaseCharacter GetTarget(Vector2 pos, Group targetGroup)
    {
        m_currentPos = pos;
        m_oppositeGroup = targetGroup;

        switch(m_targettingType)
        {
            default:
                {
                    return GetClosest();                    
                }
        }
    }

    private BaseCharacter GetClosest()
    {
        BaseCharacter target = null;
        float closestDistance = float.MaxValue;

        foreach (BaseCharacter c in m_oppositeGroup.m_group)
        {
            if (c != null)
            {
                float distance = Vector2.Distance(m_currentPos, c.transform.position);

                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    target = c;
                }
            }
        }

        return target;
    }
}
