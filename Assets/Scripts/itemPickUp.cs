
using UnityEngine;

public class itemPickUp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Item item = collision.GetComponent<Item>();
        if (item != null)
        {
            Debug.Log("Item != null");
            Debug.Log(collision.name);
            ItemDetails itemDetails = InventoryManager.Instance.GetItemDetails(item.itemCode);

            if (itemDetails.pickUp == true)
            {
                InventoryManager.Instance.AddItem(InventoryLocation.player, item, collision.gameObject);
            }
        }
    }
}
