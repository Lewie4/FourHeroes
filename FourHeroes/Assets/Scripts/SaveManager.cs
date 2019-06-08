using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveManager
{
    public static void LoadOrInitializeInventory()
    {
        if (File.Exists(Path.Combine(Application.persistentDataPath, "inventory.json")))
        {
            Debug.Log("Found file inventory.json, loading inventory.");
            Inventory.LoadFromJSON(Path.Combine(Application.persistentDataPath, "inventory.json"));
        }
        else
        {
            Debug.Log("Couldn't find inventory.json, loading from template.");
            Inventory.InitializeFromDefault();
        }
    }

    public static void SaveInventory()
    {
        Inventory.Instance.SaveToJSON(Path.Combine(Application.persistentDataPath, "inventory.json"));
    }

    public static void LoadOrInitializeHeroes()
    {
        if (File.Exists(Path.Combine(Application.persistentDataPath, "heroes.json")))
        {
            Debug.Log("Found file heroes.json, loading heroes.");
            Heroes.LoadFromJSON(Path.Combine(Application.persistentDataPath, "heroes.json"));
        }
        else
        {
            Debug.Log("Couldn't find heroes.json, heroes from template.");
            Heroes.InitializeFromDefault();
        }
    }

    public static void SaveHeroes()
    {
        Heroes.Instance.SaveToJSON(Path.Combine(Application.persistentDataPath, "heroes.json"));
    }
}
