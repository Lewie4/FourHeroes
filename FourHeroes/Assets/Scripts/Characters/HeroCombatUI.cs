using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroCombatUI : MonoBehaviour
{
    [SerializeField] private HeroHealthBarController m_healthBar;

    public void SetupHealth(float health)
    {
        m_healthBar.Setup(health);
    }

    public void UpdateHealth(float health)
    {
        m_healthBar.SetHealth(health);
    }
}
