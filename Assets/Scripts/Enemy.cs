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

    private Rigidbody2D rb;
    private Vector2 start_position;
    private Vector2 player_transform;
    private float distance;
    private EnemyHealth cast_enemy_health;
    private bool attackBlocked;


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
        
        if (collision.gameObject.CompareTag("Player"))
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
        if (collision.gameObject.CompareTag("Player"))
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
