using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.UI; 


public class FoodStock : MonoBehaviour
{
    public GameObject prefab;
    public int count = 0;
   public TextMeshPro slotText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void prefabCount()
    {
        count++;
        slotText.text = count.ToString();
    }    

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            prefabCount();
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
