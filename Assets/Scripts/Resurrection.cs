using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resurrection : MonoBehaviour
{
    public float distance_toPlayer;

    public Transform player;
    public bool isFollowPlayer = false;
    public Vector2 start_position;
    public float speed;
    public GameObject player_Tag;
    public float distance;
    public float delay;
    public float Attack_distance;

    private bool isFacingRight = true;
    private bool attackBlocked;

    public void Start()
    {
        player = GameObject.FindWithTag("Player").transform; 
    }
    public void Update()
    {
        if (distance_toPlayer <= distance)
        {
            Vector2 player_transform = new Vector2(player.position.x, transform.position.y);
            transform.position = Vector2.MoveTowards(transform.position, player_transform, speed * Time.deltaTime);


        }
        distance = Vector2.Distance(transform.position, player.position);

        if ((isFacingRight && player.position.x > transform.position.x) || (!isFacingRight && player.position.x < transform.position.x))
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }

    }
    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player") == false)
        {
            start_position = new Vector2(transform.position.x, transform.position.y);
            isFollowPlayer = true;

        }

        if (collision.gameObject.CompareTag("Enemy") == true)
        {
            if (Attack_distance >= distance)
            {
                Attack();

            }

        }

    }


    public void Attack()
    {
        if (attackBlocked)
            return;
        
        attackBlocked = true;
        StartCoroutine(DelayAttack());

    }

    private IEnumerator DelayAttack()
    {
        yield return new WaitForSeconds(delay);
        attackBlocked = false;
    }
}
