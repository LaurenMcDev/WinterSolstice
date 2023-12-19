using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grass : MonoBehaviour
{
 
    public GameObject myPrefab;
    public GameObject eKeyUI;
    public bool pickUp = false;

    public bool coll = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (coll == true && Input.GetKeyDown(KeyCode.E))
        {
            Instantiate(myPrefab, new Vector3(this.transform.position.x, this.transform.position.y, 0), Quaternion.identity);
            pickUp = true;
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "player")
        {
            Debug.Log("collision");
            coll = true;
        }
        else
            coll = false;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("player"))
        {
            pickUp = false;
        }
    }
}

