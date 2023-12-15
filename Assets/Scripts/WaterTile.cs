using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class WaterTile : MonoBehaviour
{
    public GameObject waterTile;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
   /* private void (Collider2D collision)
    {
        if (collision.CompareTag("player") && Input.GetKeyDown(KeyCode.E))
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                WaterCrop();
            }
        }
    } */

    private void WaterCrop()
    {
        Instantiate(waterTile, new Vector3(this.transform.position.x, this.transform.position.y, 0), Quaternion.identity);
    }
}
