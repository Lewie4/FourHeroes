using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StringItemDictionary : SerializableDictionary<string, BaseItem> { }

[CreateAssetMenu(menuName = "Items/Database", fileName = "ItemDatabase.asset")]
public class ItemDatabase : ScriptableObject
{
    public StringItemDictionary Items;

    public BaseItem GetActual(string key)
    {
        BaseItem a;
        if (Items.TryGetValue(key, out a))
        {
            return a;
        }

        Debug.Log("Couldn't find an Item matching key \"" + key + "\".");
        return null;
    }
}