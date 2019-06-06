using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Group : MonoBehaviour
{
    public const int GROUPSIZE = 4;

    [SerializeField] protected Hero[] m_group = new Hero[GROUPSIZE];

    public void StartCombat()
    {
        for (int i = 0; i < GROUPSIZE; i++)
        {
            if (m_group[i] != null)
            {
                m_group[i].SetupCombatStats();
                m_group[i].SetTarget(GameManager.Instance.RequestOppositionTarget(IsPlayer()));
            }
        }
    }

    public virtual bool IsPlayer()
    {
        return false;
    }

    public void Combat()
    {
        for (int i = 0; i < GROUPSIZE; i++)
        {
            if (m_group[i] != null)
            {
                if (!m_group[i].HasTarget())
                {
                    m_group[i].SetTarget(GameManager.Instance.RequestOppositionTarget(IsPlayer()));
                }
                m_group[i].TryAttack();
            }
        }
    }

    public Hero GetTarget()
    {
        int target = 0;

        for (int i = 0; i < GROUPSIZE; i++)
        {
            if (m_group[i].CheckAlive())
            {
                target = i;
                break;
            }
        }

        return m_group[target];
    }
}
