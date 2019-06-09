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

    [SerializeField] private List<HeroData> m_heroes;

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
        if (m_heroes[index] == null || m_heroes[index].CharacterStats == null || m_heroes[index].characterLevel <= 0)
        {
            return true;
        }

        return false;
    }

    public bool GetHero(int index, out HeroData hero)
    {
        if (SlotEmpty(index))
        {
            hero = null;
            return false;
        }

        hero = m_heroes[index];
        return true;
    }

    public bool RemoveHero(int index)
    {
        if (SlotEmpty(index))
        {
            return false;
        }

        m_heroes[index] = null;

        return true;
    }

    public int AddHero(HeroData hero)
    {
        for (int i = 0; i < m_heroes.Count; i++)
        {
            if (SlotEmpty(i))
            {
                m_heroes[i] = hero;
                return i;
            }
        }

        m_heroes.Add(hero);

        return m_heroes.Count - 1;
    }

    private void Save()
    {
        SaveManager.SaveInventory();
    }
}
