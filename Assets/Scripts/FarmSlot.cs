using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmSlot : MonoBehaviour
{
    public char player;

    public bool haveSeed = false;
    
    public GameObject sphere1;
    public GameObject sphere2;

    void Update()
    {
        if (IsColliding(sphere1, sphere2))
        {
            Debug.Log("Collision Detected!");
        }
    }

    bool IsColliding(GameObject sphere1, GameObject sphere2)
    {
        Vector3 position1 = sphere1.transform.position;
        Vector3 position2 = sphere2.transform.position;

        float radius1 = sphere1.transform.localScale.x / 2;
        float radius2 = sphere2.transform.localScale.x / 2;

        float distance = Vector3.Distance(position1, position2);

        return distance <= (radius1 + radius2);
    }
}

