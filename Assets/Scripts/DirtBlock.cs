using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtBlock : MonoBehaviour
{
    public GameObject seed;
    private Boolean seedplant = false;

    void Start()
    {
     
    }

    private void Update()
    {

        if(Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("E key pressed");
            PlantSeed();
        }
        /*  if(seedplant == true)
          {
              if (Input.GetKeyDown(KeyCode.E))
              {
                  Instantiate(seed, new Vector3(this.transform.position.x, this.transform.position.y), Quaternion.identity);
              }
          } */
    }


    private void PlantSeed()
    {
        if (seedplant == true)
        {
            Debug.Log("Chopping");
           Instantiate(seed, new Vector3(this.transform.position.x, this.transform.position.y), Quaternion.identity);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "player")
        {
            Debug.Log("Collision");
            seedplant = true;
  
        }
    }

  
}
