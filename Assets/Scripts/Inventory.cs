using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class Inventory
{
    [System.Serializable]
    public class slot
    {
        public CollectableType type;
        public int count;
        public int max;

        public Sprite slotIcon;

        public slot()
        {
            type = CollectableType.NONE;
            count = 0;
            max = 20;
        }

        public bool canAdd()
        {
            if(count < max)
            {
                return true;
            }
            return false;
        }

        public void addItem(Collectable item) //Pass full collectable
        {
            this.type = item.type;
            this.slotIcon = item.item;
            count++;
        }

        public void RemoveItem()
        {
            if(count > 0)
            {
                count--;

                if(count == 0)
                {
                    slotIcon = null;
                    type = CollectableType.NONE;
                }
            }
        }
    }

    public List<slot> slots = new List<slot>();

    public Inventory(int numSlots)
    {
        for(int i = 0; i < numSlots; i++)
        {
            slot slot = new slot();
            slots.Add(slot);
        }
    }

    public void Add(Collectable item)
    {
        foreach(slot slot in slots)
        {
            if(slot.type == item.type && slot.canAdd()) //Check if can be added
            {
                slot.addItem(item); //Add item to slot
                return;
            }
        }

        foreach (slot slot in slots)
        {
            if(slot.type == CollectableType.NONE)
            {
                slot.addItem(item);
                return;
            }
        }
    }

    public void Remove(int index)
    {
        slots[index].RemoveItem();
    }
}

