using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class movingPlatform : MonoBehaviour
{
    [SerializeField] private Transform pointA;
    [SerializeField] private Transform pointB;
    [SerializeField] private float speed;

    private Vector2 target;

    // Start is called before the first frame update
    void Start()
    {
        target = pointB.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, pointA.position) < 0.1f) 
        {
            target = pointB.position;
        }
        if (Vector2.Distance(transform.position, pointB.position) < 0.1f)
        {
            target = pointA.position;
        }
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    { 
        if (collision.tag == "Player")
        {
            collision.transform.SetParent(this.transform);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.transform.SetParent(null);
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(pointA.transform.position, 0.5f);
        Gizmos.DrawWireSphere(pointB.transform.position, 0.5f);
        Gizmos.DrawLine(pointA.transform.position, pointB.transform.position);
    }
}
