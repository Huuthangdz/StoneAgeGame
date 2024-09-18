using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class camera : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float speed = 40;
    //public Transform Paralax;

    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<Player>().transform;
        //Paralax = FindObjectOfType<ParalaxController>().transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.position + offset, Time.deltaTime * speed);
        //transform.position = Vector3.Lerp(transform.position, Paralax.position, Time.deltaTime * speed);
    }
}
