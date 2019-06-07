using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player/Inventory", fileName = "Inventory.asset")]
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

    public ItemInstance[] inventory;

    public static void InitializeFromDefault()
    {
        if (m_instance)
        {
            DestroyImmediate(m_instance);
        }
        m_instance = Instantiate((Inventory)Resources.Load("InventoryTemplate"));
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
        if (inventory[index] == null || inventory[index].statMult == null)
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

        item = inventory[index];
        return true;
    }

    public bool RemoveItem(int index)
    {
        if (SlotEmpty(index))
        {
            return false;
        }

        inventory[index] = null;

        return true;
    }

    public int InsertItem(ItemInstance item)
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            if (SlotEmpty(i))
            {
                inventory[i] = item;
                return i;
            }
        }
        return -1;
    }

    private void Save()
    {
        SaveManager.SaveInventory();
    }
}
