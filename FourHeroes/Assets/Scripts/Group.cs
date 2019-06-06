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

                CombatUIManager.Instance.SetupHealthBar(IsPlayer(), i, m_group[i].GetHealth());
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
                int targetNum = m_group[i].GetTarget();
                Hero target = GameManager.Instance.GetOppositionTarget(IsPlayer(), targetNum);

                if (target != null && !target.CheckAlive())
                {
                    m_group[i].SetTarget(GameManager.Instance.RequestOppositionTarget(IsPlayer()));
                }

                float damage = m_group[i].TryAttack();

                if (damage > 0)
                {
                    target.TakeDamage(damage);
                    CombatUIManager.Instance.SetupHealthBar(!IsPlayer(), targetNum, m_group[targetNum].GetHealth());
                }
            }
        }
    }

    public Hero GetTarget(int target)
    {
        return m_group[target];
    }

    public int GetAliveTarget()
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

        return target;
    }

    public bool CheckPartyAlive()
    {
        bool isAlive = false;

        for (int i = 0; i < GROUPSIZE; i++)
        {
            if (m_group[i].CheckAlive())
            {
                isAlive = true;
                break;
            }
        }
        return isAlive;
    }
}
