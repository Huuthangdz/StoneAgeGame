using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor.Tilemaps;
using UnityEngine;

public class SnailScript : CharacterEnemi
{
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody2D rbEnemy;
    [SerializeField] private GameObject pointA;
    [SerializeField] private GameObject pointB;

    private Transform currentPoint;
    private float timer;
    private bool delayActive = true;

    public float speed = 2f;
    public float damage; 

    void Start()
    {
        rbEnemy = GetComponent<Rigidbody2D>();  
        animator = GetComponent<Animator>();
        currentPoint = pointB.transform;
        animator.SetBool("Run", true);
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
        rbEnemy.velocity = Vector2.zero;
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
        if (currentPoint == pointB.transform)
        {
            rbEnemy.velocity = new Vector2(speed, 0);
        }
        else
        {
            rbEnemy.velocity = new Vector2(-speed, 0);
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
        if ( timer >= 10)
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Player>().onHit(damage);
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(pointA.transform.position, 0.5f);
        Gizmos.DrawWireSphere(pointB.transform.position, 0.5f);
        Gizmos.DrawLine(pointA.transform.position, pointB.transform.position);
    }
}
