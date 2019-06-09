using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player/Heroes", fileName = "BaseHeroes.asset")]
[System.Serializable]
public class Heroes : ScriptableObject
{
    public static Heroes Instance
    {
        get
        {
#if UNITY_EDITOR
            //Always load from json in editor
            if (!m_instance)
            {
                SaveManager.LoadOrInitializeHeroes();
            }
#endif
            if (!m_instance)
            {
                Heroes[] tmp = Resources.FindObjectsOfTypeAll<Heroes>();
                if (tmp.Length > 0)
                {
                    m_instance = tmp[0];
                    Debug.Log("Found heroes as: " + m_instance);
                }
                else
                {
                    Debug.Log("Did not find heroes, loading from file or template.");
                    SaveManager.LoadOrInitializeHeroes();
                }
            }

            return m_instance;
        }
    }

    private static Heroes m_instance;

    [SerializeField] private HeroData[] m_groupHeroes = new HeroData[Group.GROUPSIZE];
    [SerializeField] private List<HeroData> m_backupHeroes;

    public static void InitializeFromDefault()
    {
        if (m_instance)
        {
            DestroyImmediate(m_instance);
        }
        m_instance = Instantiate((Heroes)Resources.Load("BaseHeroes"));
        m_instance.hideFlags = HideFlags.HideAndDontSave;
    }

    public static void LoadFromJSON(string path)
    {
        if (m_instance)
        {
            DestroyImmediate(m_instance);
        }
        m_instance = ScriptableObject.CreateInstance<Heroes>();
        JsonUtility.FromJsonOverwrite(System.IO.File.ReadAllText(path), m_instance);
        m_instance.hideFlags = HideFlags.HideAndDontSave;
    }

    public void SaveToJSON(string path)
    {
        Debug.LogFormat("Saving heroes to {0}", path);
        System.IO.File.WriteAllText(path, JsonUtility.ToJson(this, true));
    }

    public bool SlotEmpty(int index)
    {
        if (m_backupHeroes[index] == null || m_backupHeroes[index].CharacterStats == null || m_backupHeroes[index].characterLevel <= 0)
        {
            return true;
        }

        return false;
    }

    public HeroData[] GetGroupHeroes()
    {
        return m_groupHeroes;
    }

    public bool GetGroupHero(int index, out HeroData hero)
    {
        if (index > 0 && index < m_groupHeroes.Length)
        {
            hero = m_groupHeroes[index];
            return true;
        }
        else
        {
            hero = null;
            return false;
        }
    }

    public int AddGroupHero(HeroData hero, int index)
    {
        m_groupHeroes[index] = hero;
        return index;
    }

    public int AddGroupHero(HeroData hero)
    {
        for (int i = 0; i < m_groupHeroes.Length; i++)
        {
            if (m_groupHeroes[i] == null || m_groupHeroes[i].CharacterStats == null || m_groupHeroes[i].characterLevel <= 0)
            {
                m_groupHeroes[i] = hero;
                return i;
            }
        }

        return -1;
    }

    public bool GetBackupHero(int index, out HeroData hero)
    {
        if (SlotEmpty(index))
        {
            hero = null;
            return false;
        }

        hero = m_backupHeroes[index];
        return true;
    }

    public int AddBackupHero(HeroData hero)
    {
        for (int i = 0; i < m_backupHeroes.Count; i++)
        {
            if (SlotEmpty(i))
            {
                m_backupHeroes[i] = hero;
                return i;
            }
        }

        m_backupHeroes.Add(hero);

        return m_backupHeroes.Count - 1;
    }

    public void SwapHero(int groupIndex, int backupIndex)
    {
        HeroData temp = m_backupHeroes[backupIndex];
        m_backupHeroes[backupIndex] = m_groupHeroes[groupIndex];
        m_groupHeroes[groupIndex] = temp;
    }

    private void Save()
    {
        SaveManager.SaveInventory();
    }
}
