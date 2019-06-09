using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [SerializeField] private List<ItemSlot> m_inventorySlots;
    [SerializeField] private GameObject m_itemSlotPrefab;

    void Start()
    {
        m_inventorySlots = new List<ItemSlot>();

        PopulateInitial();
    }

    public void PopulateInitial()
    {
        for (int i = 0; i < Inventory.Instance.InventorySize(); i++)
        {
            ItemInstance instance;
            // If an object exists at the specified location.
            if (Inventory.Instance.GetItem(i, out instance))
            {
                ItemSlot item = Instantiate(m_itemSlotPrefab, transform).GetComponent<ItemSlot>();
                m_inventorySlots.Add(item);
                m_inventorySlots[i].SetItem(instance);
            }
        }
    }

    public void SortInventory()
    {
        m_inventorySlots.Sort((a, b) => a.index - b.index);
    }

    public void Clear()
    {
        for (int i = 0; i < m_inventorySlots.Count; i++)
        {
            m_inventorySlots[i].RemoveItem();
        }
    }
}