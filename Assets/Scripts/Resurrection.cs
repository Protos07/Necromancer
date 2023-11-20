using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resurrection : MonoBehaviour
{
    public float distance_toPlayer;

    public Transform player;
    public Vector2 start_position;
    public float speed;
    public GameObject player_Tag;
    public float distance;
    public float delay;
    public float Attack_distance;
    public GameObject Attack_point;
    public float range;
    public LayerMask enemies;

    private bool isFacingRight = true;
    private bool attackBlocked;
    private Vector2 FollowObject_transform;
    private bool isFollowEnemy = false;


    public void Start()
    {
        player = GameObject.FindWithTag("Player").transform; 
    }
    public void Update()
    {
        Move();
        distance = Vector2.Distance(transform.position, FollowObject_transform);

        if (isFollowEnemy == true)
        {
            Attack();
            
        }

    }
    public void OnTriggerEnter2D(Collider2D collision)
    {     

        if (collision.gameObject.CompareTag("Enemy") == true)
        {
            Debug.Log("true");
            isFollowEnemy = true;
            FollowObject_transform = collision.gameObject.transform.position;
            
        }

    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") )
        {
            isFollowEnemy = false;
 
        }

    }


    public void Attack()
    {
        if (attackBlocked)
            return;
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(Attack_point.transform.position, range, enemies);
        foreach (Collider2D enemy in hitEnemies)
        {
 
            EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
            enemyHealth.ApplyDamage(0.2f);
            
        }
        attackBlocked = true;
        StartCoroutine(DelayAttack());

    }
    private void Move()
    {
        if (isFollowEnemy == false)
            FollowObject_transform = new Vector2(player.position.x, transform.position.y);

        if (distance_toPlayer <= distance)
        {            
           transform.position = Vector2.MoveTowards(transform.position, FollowObject_transform, speed * Time.deltaTime);


        }


        if ((isFacingRight && FollowObject_transform.x > transform.position.x) || (!isFacingRight && FollowObject_transform.x < transform.position.x))
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
    private IEnumerator DelayAttack()
    {
        yield return new WaitForSeconds(delay);
        attackBlocked = false;
    }
}
