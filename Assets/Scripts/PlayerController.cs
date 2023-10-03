using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private float horizontal;
    public float speed = 0f;
    public float jumpingPower = 16f;
    private bool isFacingRight = true;
    public float range;
    public LayerMask enemies;
    public float delay;

    public VariableJoystick joystick;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    public GameObject WeaponHolder;

    private Animator anim;
    private bool attackBlocked;
    private Health health;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = WeaponHolder.GetComponent<Animator>();
        health = GetComponent<Health>();
    }

    void Update()
    {
        horizontal = joystick.Horizontal;


        Flip();
    }

    private void FixedUpdate()

    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if ((isFacingRight && horizontal < 0f) || (!isFacingRight && horizontal > 0f))
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    public void Jump()
    {
        if (IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
    }

    public void Attack()
    {
        if (attackBlocked)
            return;
        anim.SetBool("IsAttack", true);
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(WeaponHolder.transform.position, range, enemies);

        foreach (Collider2D enemy in hitEnemies)
        {
            EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
            enemyHealth.ApplyDamage(health.damage);
        }
        attackBlocked = true;
        StartCoroutine(DelayAttack());

    }

    private IEnumerator DelayAttack()
    {
        yield return new WaitForSeconds(delay);
        attackBlocked = false;
    }
}
