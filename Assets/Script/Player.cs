using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEditor.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore;

public class Player : MonoBehaviour
{
    //private float horizontal;
    //private float walkSpeed = 4f;
    //private float runSpeed = 8f;
    //private float jumping = 7f;
    //private bool isFacingRight = true;
    //private float moveSpeed;
    private bool isDead;

    //[SerializeField] private Transform groundCheck;
    [SerializeField] public Animator animator;
    [SerializeField] public LayerMask Ground;
    [SerializeField] public Rigidbody2D rb;
    [SerializeField] private GameObject LoseLevel;
 
    public PlayerHealth HealthBar;
    //private bool doubleJump;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D component not found on " + gameObject.name);
        }
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        //horizontal = Input.GetAxisRaw("Horizontal");
        if (!isDead)
        {

            //jump
            //if (Input.GetButtonDown("Jump"))
            //{
            //    if (isGround())
            //    {
            //        rb.velocity = new Vector2(rb.velocity.x, jumping);
            //        doubleJump = true;
            //    } 
            //    else if ( doubleJump )
            //    {
            //        rb.velocity = new Vector2(rb.velocity.x, jumping * 0.7f);
            //        doubleJump = false;
            //    }
            //}
            
            //Attack
            //if (Input.GetKeyDown(KeyCode.F))
            //{
            //}

            //Move
            //handleMove();
            //flip();

            //die
            if (HealthBar.health <= 0)
            {
                StartCoroutine(Die());
                LoseLevel.SetActive(true);
                AudioManager.instance.Play("GameOver");
            }
        }
    }

    public void onHit(float damn)
    {
        HealthBar.health -= damn;
    }


    //private IEnumerator block()
    //{
    //    yield return new WaitForSeconds(0.5f);

    //}

    public IEnumerator Die()
    {
        isDead = true;
        animator.SetTrigger("Die");
        //GetComponent<PlayerMoverment>().OnDestroy();
        yield return new WaitForSeconds(0.8f);
        Time.timeScale = 0;
    }
    //private void handleMove()
    //{
    //    if (horizontal != 0)
    //    {
    //        moveSpeed = walkSpeed;
    //        animator.SetFloat("Walk", math.abs(horizontal));

    //        if ((Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) && horizontal != 0)
    //        {
    //            moveSpeed = runSpeed;
    //            animator.SetBool("Run", true);
    //            animator.SetFloat("Walk", 0);
    //        }
    //        rb.velocity = new Vector2(horizontal * moveSpeed, rb.velocity.y);
    //    }
    //    else
    //    {
    //        rb.velocity = new Vector2(0, rb.velocity.y);
    //        animator.SetBool("Run", false);
    //        animator.SetFloat("Walk", 0);
    //    }
    //}
    //private bool isGround()
    //{
    //    return Physics2D.Raycast(gameObject.transform.position, Vector2.down, 2f, Ground);
    //}
    //private void flip()
    //{
    //    if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
    //    {
    //        isFacingRight = !isFacingRight;
    //        Vector3 localScale = transform.localScale;
    //        localScale.x *= -1;
    //        transform.localScale = localScale;
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Heal"))
        {
            HealthBar.heal(50);
            collision.gameObject.SetActive(false);
        }
    }
    //    public void OnDestroy()
    //{
    //    rb = null;
    //}
}
