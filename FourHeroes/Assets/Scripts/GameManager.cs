using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static string PLAYERSCENE = "Player";

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

    void Update()
    {

    }
}
