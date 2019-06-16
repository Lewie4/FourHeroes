using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatController : MonoBehaviour
{
    public static CombatController Instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = FindObjectOfType<CombatController>();
            }
            return m_instance;
        }
    }

    private static CombatController m_instance;

    [SerializeField] private Group m_playerGroup;
    [SerializeField] private Group m_enemyGroup;

    private void Awake()
    {
        if (m_instance != null)
        {
            Destroy(this);
        }
        m_instance = this;
    }

    public Group GetMyGroup(bool isPlayer)
    {
        return isPlayer ? m_playerGroup : m_enemyGroup;
    }

    public Group GetOppositeGroup(bool isPlayer)
    {
        return isPlayer ? m_enemyGroup : m_playerGroup;
    }

    public void StartCombat()
    {
        foreach(Character character in m_playerGroup.m_group)
        {
            StartCharacterCombat(character);
        }

        foreach (Character character in m_enemyGroup.m_group)
        {
            StartCharacterCombat(character);
        }
    }

    private void StartCharacterCombat(Character character)
    {
        if (character != null)
        {
            character.StartCombat();
        }
    }

#if UNITY_EDITOR
    [ContextMenu("Start Combat")]
    public void DebugStartCombat()
    {
        StartCombat();
    }
#endif
}
