using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static string PLAYERSCENE = "Player";
    private static string ENEMYSCENE = "ENEMY";

    public static GameManager Instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = FindObjectOfType<GameManager>();
            }
            return m_instance;
        }
    }

    private static GameManager m_instance;

    private Group m_playerGroup;
    private Group m_enemyGroup;

    private bool m_inCombat;

    private void Awake()
    {
        if (m_instance != null)
        {
            Destroy(this);
        }
        m_instance = this;
    }

    private void Start()
    {
        if (m_playerGroup == null)
        {
            SceneManager.LoadSceneAsync(PLAYERSCENE, LoadSceneMode.Additive);
        }

        if (m_enemyGroup == null)
        {
            SceneManager.LoadSceneAsync(ENEMYSCENE, LoadSceneMode.Additive);
        }
    }

    public void RegisterPlayerGroup(PlayerGroup playerGroup)
    {
        if (m_playerGroup == null)
        {
            m_playerGroup = playerGroup;
        }
        else
        {
            Destroy(playerGroup);
        }
    }

    public void RegisterEnemyGroup(EnemyGroup enemyGroup)
    {
        if (m_enemyGroup == null)
        {
            m_enemyGroup = enemyGroup;
        }
        else
        {
            Destroy(enemyGroup);
        }
    }

    public void StartCombat()
    {
        m_inCombat = true;

        m_playerGroup.StartCombat();
        m_enemyGroup.StartCombat();
    }

    private void Update()
    {
        if (m_inCombat)
        {
            CombatControl();
        }
    }

    private void CombatControl()
    {
        m_playerGroup.Combat();
        m_enemyGroup.Combat();
    }

    public Hero RequestOppositionTarget(bool player)
    {
        return player ? m_enemyGroup.GetTarget() : m_playerGroup.GetTarget();
    }
}
