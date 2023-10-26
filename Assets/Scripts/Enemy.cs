using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;
    public float speed;
    public bool isFollowPlayer = false;
    public float Attack_distance;
    public float delay;
    public float distance;
    public bool attackBlocked;
    public Vector2 start_position;
    public string name_FollowObject;

    private Rigidbody2D rb;
    
    private Vector2 player_transform;
    private EnemyHealth cast_enemy_health;  
    private bool isFacingRight = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cast_enemy_health = GetComponent<EnemyHealth>();
    }

    
    void Update()
    {
        
        if (isFollowPlayer == true)
        {
            Move();
        }
        distance = Vector2.Distance(transform.position, player.transform.position);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag(name_FollowObject))
        {
            if (isFollowPlayer == false)
            {
                start_position = new Vector2(transform.position.x, transform.position.y);
                isFollowPlayer = true;

            }

        }
          
        
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(name_FollowObject))
        {
            isFollowPlayer = false;
            
        }
        
    }

    public void Move()
    {
        Vector2 player_transform = new Vector2(player.transform.position.x, transform.position.y);
        transform.position = Vector2.MoveTowards(transform.position, player_transform, speed * Time.deltaTime);
        if (Attack_distance >= distance)
        {            
            Attack();

        }

        if ((isFacingRight && player.position.x > transform.position.x) || (!isFacingRight && player.position.x < transform.position.x))
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
        Health health = player.GetComponent<Health>();
        health.ApplyDamage((Random.Range(cast_enemy_health.min_damage, cast_enemy_health.max_damage)));
        attackBlocked = true;
        StartCoroutine(DelayAttack());

    }
    public void Patrol()
    {

    }
    public void ReturnToStart()
    {
        rb.MovePosition(start_position);
    }

    private IEnumerator DelayAttack()
    {
        yield return new WaitForSeconds(delay);
        attackBlocked = false;
    }
}
