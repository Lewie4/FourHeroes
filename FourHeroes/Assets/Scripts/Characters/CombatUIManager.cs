using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatUIManager : MonoBehaviour
{
    [SerializeField] protected HeroHealthBarController[] m_players = new HeroHealthBarController[Group.GROUPSIZE];
    [SerializeField] protected HeroHealthBarController[] m_enemies = new HeroHealthBarController[Group.GROUPSIZE];

    public static CombatUIManager Instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = FindObjectOfType<CombatUIManager>();
            }
            return m_instance;
        }
    }

    private static CombatUIManager m_instance;

    private void Awake()
    {
        if (m_instance != null)
        {
            Destroy(this);
        }
        m_instance = this;
    }

    public void SetupHealthBar(bool player, int target, float health)
    {
        if (player)
        {
            m_players[target].Setup(health);
        }
        else
        {
            m_enemies[target].Setup(health);
        }
    }

    public void UpdateHealthBar(bool player, int target, float health)
    {
        if (player)
        {
            m_players[target].SetHealth(health);
        }
        else
        {
            m_enemies[target].SetHealth(health);
        }
    }
}
