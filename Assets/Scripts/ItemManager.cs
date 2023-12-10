using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    //use a dictionary to tie collectable and item together
    public Collectable[] collectItem;

    private Dictionary<CollectableType, Collectable> collectableDict = new Dictionary<CollectableType, Collectable>();

    private void Awake()
    {
        foreach(Collectable item in collectItem)
        {
            AddItem(item);
        }
    }

    private void AddItem(Collectable item)
    {
        if(!collectableDict.ContainsKey(item.type))
            {
            collectableDict.Add(item.type, item);
        }
    }

    public Collectable GetItem(CollectableType type)
    {
        if(collectableDict.ContainsKey(type))
        {
            return collectableDict[type];
        }

        return null;
    }
}
