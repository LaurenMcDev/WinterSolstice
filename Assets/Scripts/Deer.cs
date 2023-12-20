using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Deer : MonoBehaviour
{
    public Transform left, right;
    public float moveSpeed = 2;
    private Rigidbody2D rb;
    public bool moveRight;

    public panel knifePanel;
    public Image deerImage;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            deerImage = GetComponent<Image>();
            deerImage.gameObject.SetActive(true);
        }
        else
        {
            deerImage.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        /*  if(moveRight && transform.position.x > right.position.x)
          {
              moveRight = false;
          }
          if(!moveRight && transform.position.x < left.position.x)
          {
              moveRight = true;
          }

          if(moveRight)
          {
              rb.velocity = new Vector3(moveSpeed, rb.velocity.y, 0f);
          }
          else
          {
              rb.velocity = new Vector3(-moveSpeed, rb.velocity.y, 0f);
          }
      } */
    }
}
