using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Group : MonoBehaviour
{
    public const int GROUPSIZE = 4;

    [SerializeField] private Hero[] m_group = new Hero[GROUPSIZE];

    public void StartCombat()
    {
        for (int i = 0; i < GROUPSIZE; i++)
        {
            if (m_group[i] != null)
            {
                m_group[i].SetupCombatStats();
            }
        }
    }

    public void Combat()
    {
        for (int i = 0; i < GROUPSIZE; i++)
        {
            if (m_group[i] != null)
            {
                m_group[i].TryAttack();
            }
        }
    }
}
