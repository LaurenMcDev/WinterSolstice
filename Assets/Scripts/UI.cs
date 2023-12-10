using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    public GameObject inventoryPanel;

    public Player player;

    public List<SlotUI> slots = new List<SlotUI>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleInventory();
        }
    }

    public void ToggleInventory()
    {
        if (!inventoryPanel.activeSelf)
        {
            inventoryPanel.SetActive(true);
            Setup();
        } else
        {
            inventoryPanel.SetActive(false);
        }
    }

    public void Setup()
    {
        if(slots.Count == player.inventory.slots.Count)
        {
            for(int i = 0; i < slots.Count; i++)
            {
                if (player.inventory.slots[i].type != CollectableType.NONE)
                {
                    slots[i].SetItem(player.inventory.slots[i]);
                 
                }
                else
                {
                    slots[i].Empty();
                }
            }
        }    
    }

    public void Remove(int slotID)
    {
        Collectable itemDrop = GameManager.instance.itemManager.GetItem(player.inventory.slots[slotID].type);

        if (itemDrop != null)
        {
            player.Drop(itemDrop);
            player.inventory.Remove(slotID);
            Setup();
        }
    }
}
