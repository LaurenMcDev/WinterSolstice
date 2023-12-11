using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crop : MonoBehaviour
{
    public Sprite spriteChange1;
    public Sprite spriteChange2;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ChangeSprite(5f));
    }

    IEnumerator ChangeSprite(float delayInSeconds)
    {
        yield return new WaitForSeconds(delayInSeconds);

        // Change the sprite after the delay
        ChangeSprite();
    }

    void ChangeSprite()
    {
        // Assuming you have a SpriteRenderer component attached to the GameObject
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        // Change the sprite to the new one
        spriteRenderer.sprite = spriteChange1;
    }

}
