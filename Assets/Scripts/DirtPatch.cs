using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DirtPatch : MonoBehaviour
{
  //  public Sprite newSprite; // Assign the new sprite in the Unity Editor
    private SpriteRenderer spriteRenderer;
    public GameObject myPrefab;
    public GameObject water;
    public GameObject Crop;
    bool watered = false;

    private void Start()
    { 
        spriteRenderer = GetComponent<SpriteRenderer>();
        

        if (spriteRenderer == null)
        {
            Debug.LogError("component not found");
        }

        StartCoroutine(GrowDelay(10f));
    }

    private void Update()
    {
       
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("player") && Input.GetKeyDown(KeyCode.E))
        {
            InteractWithObject();
        }

       else if (collision.CompareTag("player") && Input.GetKeyDown(KeyCode.C))
        {
            WaterCrop();
        }
    }


    private void InteractWithObject()
    {
        // Check if a new sprite is assigned
            // Change the sprite
            Instantiate(myPrefab, new Vector3(this.transform.position.x, this.transform.position.y, 0), Quaternion.identity);
    }

    private void WaterCrop()
    {

            // Change the sprite
            Instantiate(water, new Vector3(this.transform.position.x, this.transform.position.y, 0), Quaternion.identity);
            watered = true;

        if (watered == true)
        {
           // GameObject.DestroyImmediate(myPrefab);
           // Instantiate(Crop, new Vector3(this.transform.position.x, this.transform.position.y + 1, 0), Quaternion.identity);
        }
    }

    IEnumerator GrowDelay (float delayInSeconds)
    {
        yield return new WaitForSeconds(delayInSeconds);

        // Change the sprite after the delay
        ChangeSprite();
    }

    void ChangeSprite()
    {
       // Destroy(myPrefab);
        Instantiate(Crop, new Vector3(this.transform.position.x, this.transform.position.y + 0.5f, 0), Quaternion.identity);
        }

    }

