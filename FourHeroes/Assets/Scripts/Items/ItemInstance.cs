using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemInstance
{
    public string itemName;
    public int ilvl;
    public Stat stat1;
    public Stat stat2;
    public Stat stat3;
    public Stat stat4;
    public bool isNew;  //Show new in the inventory

    private BaseItem itemStats = null;

    public BaseItem ItemStats
    {
        get
        {
            if (itemStats == null)
            {
                itemStats = ((ItemDatabase)Resources.Load("ItemDatabase")).GetActual(itemName);
            }

            return itemStats;
        }
    }

    public ItemInstance(BaseItem itemStats, int ilvl, Stat stat1, Stat stat2, Stat stat3, Stat stat4)
    {
        this.itemStats = itemStats;
        this.ilvl = ilvl;
        this.stat1 = stat1;
        this.stat2 = stat2;
        this.stat3 = stat3;
        this.stat4 = stat4;
    }
}
