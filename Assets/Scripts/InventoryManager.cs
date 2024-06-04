using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : Singleton<InventoryManager> 
{
    private Dictionary<int, ItemDetails> itemDetailsDictionary;

    public List<InventoryItem>[] inventoryLists;

    [HideInInspector] public int[] inventoryListCapacityIntArray;

    [SerializeField] private ItemList itemList = null;
    public Item item;

    protected override void Awake() 
    {
        base.Awake();
        CreateInventoryLists();
        CreateItemDetailsDictionary();
    }

    private void CreateInventoryLists()
    {
        inventoryLists = new List<InventoryItem>[(int)InventoryLocation.count];

        for(int i = 0; i < (int)InventoryLocation.count; i++)
        {
            inventoryLists[i] = new List<InventoryItem>();
        }

        inventoryListCapacityIntArray = new int[(int)InventoryLocation.count];

        inventoryListCapacityIntArray[(int)InventoryLocation.player] = Settings.playerInitialInventoryCapacity;
    }


  private void CreateItemDetailsDictionary()
    {
        itemDetailsDictionary = new Dictionary<int, ItemDetails>();

        foreach(ItemDetails itemDetails in itemList.itemDetails)
        {
            itemDetailsDictionary.Add(itemDetails.itemCode, itemDetails);
        }
    }

    public void AddItem(InventoryLocation inventoryLocation, Item item, GameObject gameObjectToDelete)
    {
        AddItem(inventoryLocation, item);
        Destroy(gameObjectToDelete);
    } 

    public void AddItem(InventoryLocation inventoryLocation, Item item)
    {
        int itemCode = item.itemCode;

        List<InventoryItem> inventoryList = inventoryLists[(int)inventoryLocation];

        int itemPosition = FindItemInInventory(inventoryLocation, itemCode);

        if(itemPosition != 1)
        {
            AddItemAtPosition(inventoryList, itemCode, itemPosition);
        } else
        {
            AddItemAtPosition(inventoryList, itemCode);
        }

        EventHandler.CallInventoryUpdateEvent(inventoryLocation, inventoryLists[(int)inventoryLocation]);
    }

    public void AddItemAtPosition(List<InventoryItem> inventoryList, int itemCode)
    {

        InventoryItem inventoryItem = new InventoryItem();
        item.itemCode = itemCode;
       // item.itemQuantity = 1;
        inventoryList.Add(inventoryItem);

      //  DebugPrintInventorylist(inventoryList);
    }

    public int FindItemInInventory(InventoryLocation inventoryLocation, int itemCode)
    {
        List<InventoryItem> inventoryList = inventoryLists[(int)inventoryLocation];

        for(int i = 0; i < inventoryList.Count; i++)
        {
            if (inventoryList[i].itemCode == itemCode)
            {
                return 1;
            }
        }
        return -1;

    }

   public void AddItemAtPosition(List<InventoryItem> inventoryList, int itemCode, int itemPosition)
    { }

    public ItemDetails GetItemDetails(int itemCode)
    {
        ItemDetails itemDetails;

        if(itemDetailsDictionary.TryGetValue(itemCode, out itemDetails))
        {
            return itemDetails;
        } 
        else
        {
            return null;
        }
    }
}
