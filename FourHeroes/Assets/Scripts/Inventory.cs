using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player/Inventory", fileName = "BaseInventory.asset")]
[System.Serializable]
public class Inventory : ScriptableObject
{
    public static Inventory Instance
    {
        get
        {
            if (!m_instance)
            {
                Inventory[] tmp = Resources.FindObjectsOfTypeAll<Inventory>();
                if (tmp.Length > 0)
                {
                    m_instance = tmp[0];
                    Debug.Log("Found inventory as: " + m_instance);
                }
                else
                {
                    Debug.Log("Did not find inventory, loading from file or template.");
                    SaveManager.LoadOrInitializeInventory();
                }
            }

            return m_instance;
        }
    }

    private static Inventory m_instance;

    [SerializeField] private List<ItemInstance> m_itemInventory;

    public static void InitializeFromDefault()
    {
        if (m_instance)
        {
            DestroyImmediate(m_instance);
        }
        m_instance = Instantiate((Inventory)Resources.Load("BaseInventory"));
        m_instance.hideFlags = HideFlags.HideAndDontSave;
    }

    public static void LoadFromJSON(string path)
    {
        if (m_instance)
        {
            DestroyImmediate(m_instance);
        }
        m_instance = ScriptableObject.CreateInstance<Inventory>();
        JsonUtility.FromJsonOverwrite(System.IO.File.ReadAllText(path), m_instance);
        m_instance.hideFlags = HideFlags.HideAndDontSave;
    }

    public void SaveToJSON(string path)
    {
        Debug.LogFormat("Saving inventory to {0}", path);
        System.IO.File.WriteAllText(path, JsonUtility.ToJson(this, true));
    }

    public bool SlotEmpty(int index)
    {
        if (m_itemInventory[index] == null || m_itemInventory[index].itemStats == null)
        {
            return true;
        }

        return false;
    }

    public bool GetItem(int index, out ItemInstance item)
    {
        if (SlotEmpty(index))
        {
            item = null;
            return false;
        }

        item = m_itemInventory[index];
        return true;
    }

    public bool RemoveItem(int index)
    {
        if (SlotEmpty(index))
        {
            return false;
        }

        m_itemInventory[index] = null;

        return true;
    }

    public int InsertItem(ItemInstance item)
    {
        for (int i = 0; i < m_itemInventory.Count; i++)
        {
            if (SlotEmpty(i))
            {
                m_itemInventory[i] = item;
                return i;
            }
        }

        m_itemInventory.Add(item);

        return m_itemInventory.Count - 1;
    }

    private void Save()
    {
        SaveManager.SaveInventory();
    }
}
