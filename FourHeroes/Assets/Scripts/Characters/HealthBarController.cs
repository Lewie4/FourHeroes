using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroHealthBarController : MonoBehaviour
{
    private Slider m_healthBar;

    public void Setup(float maxHealth)
    {
        if (m_healthBar == null)
        {
            m_healthBar = GetComponent<Slider>();
        }

        m_healthBar.minValue = 0;
        m_healthBar.maxValue = maxHealth;
        m_healthBar.value = maxHealth;
    }

    public void SetHealth(float currentHealth)
    {
        m_healthBar.value = currentHealth;
    }
}
