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
    private bool m_playerWin;

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
        m_playerWin = false;

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
        bool playerAlive = m_playerGroup.CheckPartyAlive();
        bool enemyAlive = m_enemyGroup.CheckPartyAlive();

        if (!enemyAlive)
        {
            m_inCombat = false;
            m_playerWin = true;

            Debug.Log("<color=green> Player has won!</color>");
        }
        else if (!playerAlive)
        {
            m_inCombat = false;
            m_playerWin = false;
            Debug.Log("<color=red> Player has lost!</color>");
        }
        else
        {
            m_playerGroup.Combat();
            m_enemyGroup.Combat();
        }
    }

    public Hero RequestOppositionTarget(bool player)
    {
        return player ? m_enemyGroup.GetTarget() : m_playerGroup.GetTarget();
    }
}
