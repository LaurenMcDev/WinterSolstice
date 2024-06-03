using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{       
    [SerializeField]
    private int itemCode1;

    private SpriteRenderer spriteRenderer;

    public int itemCode { get { return ItemCode; } set { ItemCode = value; } }

    public int ItemCode { get => itemCode1; set => itemCode1 = value; }

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if(itemCode != 0)
        {
            Init(itemCode);
        }
    }

    public void Init(int codeItem)
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
