//using Mono.Cecil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset;
    public Vector3 targetpos;
    public float smoothing;

    [SerializeField] private Transform target;

    void Start()
    {
        offset = transform.position - target.position;
    }
    void FixedUpdate()
    {

        transform.position = target.position + offset;


        //targetpos = new Vector3(player.transform.position.x + offset.x, player.transform.position.y + offset.y, player.transform.position.z + offset.z);


        //transform.position = Vector3.Lerp(transform.position, targetpos, smoothing * Time.deltaTime);

  
    }


}