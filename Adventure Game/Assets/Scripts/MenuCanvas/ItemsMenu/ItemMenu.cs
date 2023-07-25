using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemMenu : MonoBehaviour
{

    public Player player;
    public InventorySlots[] inventorySlots;
    public GameObject inventoryItemPrefab;


    public void addItem(Item item)
    {

        for (int i = 0; i < inventorySlots.Length; i++) {
            InventorySlots slot = inventorySlots[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot == null)
            {
                SpawnNewItem(item, slot);
                return;
            }
        }

    }


        void SpawnNewItem(Item item, InventorySlots slot)
        {
            GameObject newItemGo = Instantiate(inventoryItemPrefab, slot.transform);
            InventoryItem inventoryItem = newItemGo.GetComponent<InventoryItem>();
            inventoryItem.InitialiseItem(item, player);
        }
}
