using System.Collections.Generic;
using UnityEngine.Rendering;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemList", menuName = "Scriptable Objects/Item/ItemList")]
public class ItemList : ScriptableObject
{
    [SerializeField]
    public List<ItemDetails> itemDetails;

    

}
