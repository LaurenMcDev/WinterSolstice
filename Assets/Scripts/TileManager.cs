using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileManager : MonoBehaviour
{
    [SerializeField] private Tilemap interactable;
    [SerializeField] private Tile interact;
   void Start()
    {
        foreach(var position in interactable.cellBounds.allPositionsWithin)
        {
            interactable.SetTile(position, interact);
        }
    }


}
