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

    public static void LoadFromTemplate()
    {
        Inventory.InitializeFromDefault();
    }
}
