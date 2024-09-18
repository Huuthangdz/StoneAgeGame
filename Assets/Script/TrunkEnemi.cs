using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrunkEnemi : CharacterEnemi
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform pointBullet;
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject pointA;
    [SerializeField] private GameObject pointB;
    [SerializeField] private float speed = 50f;

    private Rigidbody2D rb;
    private Transform currentPoint;
    private float timer;
    private bool delayActive = true;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
        currentPoint = pointB.transform;
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
        rb.velocity = Vector2.zero;
         
        yield return new WaitForSeconds(3f);
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
        if (currentPoint == pointB.transform)
        {
            rb.velocity = new Vector2(speed, 0);
        }
        else
        {
            rb.velocity = new Vector2(-speed, 0);
        }
        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointB.transform)
        {
            Flip();
            currentPoint = pointA.transform;
        }
        else if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointA.transform)
        {
            Flip();
            currentPoint = pointB.transform;
        } 
        
        if ( timer >= 7)
        {
            Idile(); 
            delayActive = false;
        }
    }
    public IEnumerator shoot()
    {
        animator.SetBool("Attack", true);
        yield return new WaitForSeconds(0.4f);
        Instantiate(bullet, pointBullet.position, Quaternion.identity);
        animator.SetBool("Attack", false);
    }

    private void Flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(pointA.transform.position, 0.5f);
        Gizmos.DrawWireSphere(pointB.transform.position, 0.5f);
        Gizmos.DrawLine(pointA.transform.position, pointB.transform.position);
    }
}
