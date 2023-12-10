using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtPatch : MonoBehaviour
{
  //  public Sprite newSprite; // Assign the new sprite in the Unity Editor
    private SpriteRenderer spriteRenderer;
    public GameObject myPrefab;
    public GameObject water;

    private void Start()
    {
        // Ensure that the object has a SpriteRenderer component
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (spriteRenderer == null)
        {
            Debug.LogError("component not found");
        }
    }

    private void Update()
    {
        // Example: Check for player collision and the "E" key press to interact with the object
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("player") && Input.GetKeyDown(KeyCode.E))
        {
            InteractWithObject();
        }

        if (collision.CompareTag("player") && Input.GetKeyDown(KeyCode.C))
        {
            WaterCrop();
        }
    }


    private void InteractWithObject()
    {
        // Check if a new sprite is assigned
        if (myPrefab != null)
        {
            // Change the sprite
            Instantiate(myPrefab, new Vector3(this.transform.position.x, this.transform.position.y, 0), Quaternion.identity);
        }
    }

    private void WaterCrop()
    {
        // Check if a new sprite is assigned
        if (myPrefab != null)
        {
            // Change the sprite
            Instantiate(water, new Vector3(this.transform.position.x, this.transform.position.y, 0), Quaternion.identity);
        }
    }
}
