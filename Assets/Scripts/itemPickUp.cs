
using UnityEngine;

public class itemPickUp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Item item = collision.GetComponent<Item>();
        if(item != null)
        {
            ItemDetails itemDetails = InventoryManager.Instance.GetItemDetails(itemCode: item.itemCode);

            if (itemDetails.pickUp == true) ;
            {
                InventoryManager.Instance.AddItem(InventoryLocation.player, item, collision.gameObject);
            }
        }    
    }
}
