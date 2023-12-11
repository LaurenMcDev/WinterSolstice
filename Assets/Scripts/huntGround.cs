using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class huntGround : MonoBehaviour
{
    public GameObject animalPrint; // Assign the object prefab in the Inspector
   // public float chanceOfInitialization = 5f;
    bool colliding = false;

    /*private void Update()
    {
        if (colliding == true && Random.value < chanceOfInitialization)
        {
            // Instantiate the object at the position of the box
            Instantiate(objectToInstantiate, transform.position, Quaternion.identity);
        }
    } */

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Vector3 pos = new Vector3(Random.value, Random.value, 0);
            colliding = true;
            Instantiate(animalPrint, pos, Quaternion.identity);
            Debug.Log("drawn!");
          /*  if(animalPrint.transform.position.x >= this.transform.position.x || animalPrint.transform.position.y >= this.transform.position.y)
            {
                Destroy(animalPrint);
                pos = new Vector3(Random.value, Random.value, 0);
                Instantiate(animalPrint, pos, Quaternion.identity);
            }*/

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            colliding = false;

        }
    } 
}
