using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public bool isFollowObject = false;
    public float Attack_distance;
    public float delay;
    public float distance;
    public bool attackBlocked;
    public GameObject triagle;

    private Rigidbody2D rb;

    public GameObject AttackObject;
    private EnemyHealth cast_enemy_health;
    private bool isFacingRight = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cast_enemy_health = GetComponent<EnemyHealth>();
        //AttackObject = GameObject.FindWithTag("Player");
    }


    void Update()
    {

        if (isFollowObject == true && AttackObject != null)
        {
            Move();
        }
        if (AttackObject != null)
            distance = Vector2.Distance(transform.position, AttackObject.transform.position);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {     
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Resurrection"))
        {
            if(isFollowObject == false )
            {
                RaycastHit2D hit = Physics2D.Raycast(triagle.transform.position, Vector2.left);

                if (hit.collider != null)
                {
                    AttackObject = hit.collider.gameObject;
                    isFollowObject = true;
                }
            }
            
        }

    }

    public void OnTriggerExit2D(Collider2D collision)
    {      
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Resurrection"))
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position , Vector2.left);

            if (hit.collider != null)
            {
                AttackObject = hit.collider.gameObject;
            }
        }
    }

    public void Move()
    {
        Vector2 player_transform = new Vector2(AttackObject.transform.position.x, transform.position.y);
        transform.position = Vector2.MoveTowards(transform.position, player_transform, speed * Time.deltaTime);
        if (Attack_distance >= distance)
        {            
            Attack();

        }

        if ((isFacingRight && AttackObject.transform.position.x > transform.position.x) || (!isFacingRight && AttackObject.transform.position.x < transform.position.x))
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
       



    }
    public void Attack()
    {
        if (attackBlocked)
            return;
        Health health = AttackObject.GetComponent<Health>();
        health.ApplyDamage((Random.Range(cast_enemy_health.min_damage, cast_enemy_health.max_damage)));
        attackBlocked = true;
        StartCoroutine(DelayAttack());

    }
    public void Patrol()
    {

    }
    public void ReturnToStart()
    {

    }

    private IEnumerator DelayAttack()
    {
        yield return new WaitForSeconds(delay);
        attackBlocked = false;
    }
}
