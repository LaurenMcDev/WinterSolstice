using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.Build;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public CollectableType type;
    public Sprite item;

    public Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
      //  bool playerDir = Input.GetKey(KeyCode.E);
        Player player = collision.GetComponent<Player>();
        if (collision.tag == "player" && Input.GetKeyDown(KeyCode.E))
        {
                player.inventory.Add(this);
                Destroy(this.gameObject);
                Debug.Log("collision");

        }
    }
}

public enum CollectableType
{
    NONE, CARROT_SEED
}
