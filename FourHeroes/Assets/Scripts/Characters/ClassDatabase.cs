using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StringClassDictionary : SerializableDictionary<string, ClassData> { }

[CreateAssetMenu(menuName = "Classes/Database", fileName = "ClassDatabase.asset")]
public class ClassDatabase : ScriptableObject
{
    public StringClassDictionary Classes;

    public ClassData GetActual(string key)
    {
        if (!string.IsNullOrEmpty(key))
        {
            ClassData a;
            if (Classes.TryGetValue(key, out a))
            {
                return a;
            }
        }

        Debug.Log("Couldn't find an Class matching key \"" + key + "\".");
        return null;
    }
}