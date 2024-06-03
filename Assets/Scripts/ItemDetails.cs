using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

[System.Serializable]

public class ItemDetails
{
    public int itemCode;
    public ItemType itemType;
    public Sprite itemSprite;
    public string itemDesc;
    public short itemGridRadius;
    public float itemUseRadius;

    public bool startItem;
    public bool pickUp;
    public bool drop;
    public bool eaten;
    public bool carried;
}