using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SlotUI : MonoBehaviour
{
    public Image itemIcon;
    public TextMeshProUGUI quantity;
   
    public void SetItem(Inventory.slot slot)
    {
        if(slot != null)
        {
            itemIcon.sprite = slot.slotIcon;
            itemIcon.color = new Color(1, 1, 1, 1);
            quantity.text = slot.count.ToString();
        }
    }

    public void Empty()
    {
        itemIcon.sprite = null;
        quantity.text = " ";
    } 
}
