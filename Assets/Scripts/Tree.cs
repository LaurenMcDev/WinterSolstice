using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Tree : MonoBehaviour
{
    public GameObject myPrefab;
    public GameObject eKeyUI;

    bool collide = false;

    [SerializeField] private AudioSource chop;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        chop = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("E key pressed");
            ChoppingAction();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "player")
        {
            collide = true;
            Instantiate(eKeyUI, new Vector3(this.transform.position.x, this.transform.position.y - 1, 0), Quaternion.identity);
            Debug.Log("collision");
        }
    }


    private void ChoppingAction()
    {
        if (collide == true)
        {
            Debug.Log("Chopping");
            // animator.SetTrigger("chopping");
            chop.Play();
            Instantiate(myPrefab, new Vector3(this.transform.position.x, this.transform.position.y - 2, 0), Quaternion.identity);
            Destroy(eKeyUI);
            Destroy(this.gameObject);
        }
    }
}

    /* private void OnTriggerEnter2D(Collider2D collision)
     {
         animator = GetComponent<Animator>();
         chop = GetComponent<AudioSource>();

         if (collision.tag == "player")
         {
             Instantiate(eKeyUI, new Vector3(this.transform.position.x, this.transform.position.y - 1, 0), Quaternion.identity);
             Debug.Log("collision");
             if (Input.GetKeyDown(KeyCode.E))
            {
                 chop.PlayOneShot(chopSound);
                 animator.SetTrigger("chopping");
                 Instantiate(myPrefab, new Vector3(this.transform.position.x, this.transform.position.y - 2, 0), Quaternion.identity);
                 Destroy(this.gameObject);
             }
         }
     } */

