using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class PlayerMoverment : MonoBehaviour
{
    PlayerMove control;
    private float direction = 0;
    private bool isFacingRight = true;
    private bool isGround;
    private int numberOfJump = 0;
    private GameObject attackArea = default;
    private bool attacking = false;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask Ground;
    [SerializeField] private attackAreaPlayer AttackArea;
    public float jumpForce = 7;
    public float speed;
    private void Awake()
    {
        control = new PlayerMove();
        control.Enable();

        attackArea = transform.GetChild(0).gameObject;
        attackArea.SetActive(false);

        control.Ground.Move.performed += ctx =>
        {
            direction = ctx.ReadValue<float>();
        };

        control.Ground.Jump.performed += ctx => Jump();

        control.Ground.Attack.performed += ctx => StartCoroutine(attack());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = new Vector2(direction * speed * Time.fixedDeltaTime, rb.velocity.y);
        animator.SetFloat("Run", Mathf.Abs(direction));
        isGround = Physics2D.OverlapCircle(groundCheck.position, 0.1f, Ground);
        if ( isFacingRight && direction < 0 || !isFacingRight && direction > 0)
        {
            Flip();
        }
    }
    private void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.localScale = new Vector2(transform.localScale.x * -1,transform.localScale.y);
    }

    private void Jump()
    {
        if (isGround)
        {
            numberOfJump = 0;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            numberOfJump++;
            AudioManager.instance.Play("FirstJump");
        }
        else
        {
            if (numberOfJump == 1)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                numberOfJump++;
                AudioManager.instance.Play("SecondJump");
            }
        }
    }
    private IEnumerator attack()
    {
        attacking = true;
        attackArea.SetActive(attacking);
        animator.SetBool("Attack", true);

        yield return new WaitForSeconds(0.5f);

        endAttack();
    }
    private void endAttack()
    {
        attacking = false;
        attackArea.SetActive(attacking);
        animator.SetBool("Attack", false);
    }
}
