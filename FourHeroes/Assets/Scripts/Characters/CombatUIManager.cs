using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatUIManager : MonoBehaviour
{
    [SerializeField] private HeroCombatUI[] m_players = new HeroCombatUI[Group.GROUPSIZE];
    [SerializeField] private HeroCombatUI[] m_enemies = new HeroCombatUI[Group.GROUPSIZE];

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
            m_players[target].SetupHealth(health);
        }
        else
        {
            m_enemies[target].SetupHealth(health);
        }
    }

    public void UpdateHealthBar(bool player, int target, float health)
    {
        if (player)
        {
            m_players[target].UpdateHealth(health);
        }
        else
        {
            m_enemies[target].UpdateHealth(health);
        }
    }
}
