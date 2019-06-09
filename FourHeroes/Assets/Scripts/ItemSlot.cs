using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemSlot : MonoBehaviour
{
    public int index = 0;

    [SerializeField] private TextMeshProUGUI m_itemType;
    [SerializeField] private TextMeshProUGUI m_itemLevel;
    [SerializeField] private TextMeshProUGUI m_itemQuality;

    private ItemInstance m_itemInstance = null;    // Inventory backend representation.

    // TODO: it would be better if we used SetActive() etc rather than Instantiate/Destroy.
    // Use this method to set a slot's item.
    // The slot will automatically instantiate the gameobject associated with the item.
    public void SetItem(ItemInstance instance)
    {
        this.m_itemInstance = instance;
        Setup();
    }

    // Remove the item from the slot, and destroy the associated gameobject.
    public void RemoveItem()
    {
        this.m_itemInstance = null;
        Destroy(this.gameObject);
    }

    private void Setup()
    {
        m_itemType.text = m_itemInstance.ItemStats.itemType.ToString();
        m_itemLevel.text = m_itemInstance.ilvl.ToString();
        m_itemQuality.text = m_itemInstance.ItemStats.quality.ToString();
    }
}