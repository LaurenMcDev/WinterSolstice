using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class panel : MonoBehaviour
{
    public RectTransform Panel1;
    public RectTransform Panel2;
    public int buttonPress = 0;
    // Start is called before the first frame update
    void Start()
    {
       // Panel.gameObject.SetActive(true);
       // Panel2.gameObject.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(Panel2);
            Destroy(this.gameObject);
           // Panel.gameObject.SetActive(false);
           // Panel2.gameObject.SetActive(true);
           // Panel.localScale = new Vector3(0, 0);
           //  Panel2.localScale = new Vector3(1, 1);
        }
    }
}

