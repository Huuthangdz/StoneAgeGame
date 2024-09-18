using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class RhinoScript : CharacterEnemi
{
    [SerializeField] private Transform PointA;
    [SerializeField] private Transform PointB;
    [SerializeField] private Animator animator;
    [SerializeField] private float speed;

    private Rigidbody2D Rigidbody2D;
    private Transform currentPoint;
    private float timer;
    private bool delayActive = true;
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        currentPoint = PointA.transform;
        
    }

    // Update is called once per frame
    void Update()
    { 
        timer += Time.deltaTime;

        if (delayActive)
        {
            Move();
        }
        else
        {
            StartCoroutine(Idile());
        }
        
    }
    
    
    private IEnumerator Idile()
    {
        animator.SetBool("Idile", true);
        Rigidbody2D.velocity = Vector2.zero;
        yield return new WaitForSeconds(2f);
        StopIdile();
    }


    private void StopIdile()
    {
        animator.SetBool("Idile", false);
        delayActive = true;
        timer = 0;
    }
    private void Move()
    {
        Vector2 Point = currentPoint.position - transform.position;
        if (currentPoint == PointA.transform)
        {
            Rigidbody2D.velocity = new Vector2(speed, 0);
        }
        else
        {
            Rigidbody2D.velocity = new Vector2(-speed, 0);
        }
        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == PointB.transform)
        {
            Flip();
            currentPoint = PointA.transform;
        }
        else if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == PointA.transform)
        {
            Flip();
            currentPoint = PointB.transform;
        }

        if ( timer >= 8)
        {
            Idile();
            delayActive = false;
        }
    }
    private void Flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(PointA.transform.position, 0.5f);
        Gizmos.DrawWireSphere(PointB.transform.position, 0.5f);
        Gizmos.DrawLine(PointA.transform.position,PointB.transform.position);
    }
}
