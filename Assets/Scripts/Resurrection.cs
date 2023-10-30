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

    private bool isFacingRight = true;
    public float distance;

    public void Start()
    {
        player.gameObject = GameObject.FindWithTag("Respawn");
    }
    public void Update()
    {
        if (distance_toPlayer <= distance)
        {
            Vector2 player_transform = new Vector2(player.transform.position.x, transform.position.y);
            transform.position = Vector2.MoveTowards(transform.position, player_transform, speed * Time.deltaTime);


        }
        distance = Vector2.Distance(transform.position, player.transform.position);

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

    }


    //public void Attack()
    //{
    //    if (attackBlocked)
    //        return;
    //    Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(WeaponHolder.transform.position, range, enemies);

    //    foreach (Collider2D enemy in hitEnemies)
    //    {
    //        EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
    //        enemyHealth.ApplyDamage((Random.Range(health.min_damage, health.max_damage)));

    //    }
    //    attackBlocked = true;
    //    StartCoroutine(DelayAttack());

    //}

    //private IEnumerator DelayAttack()
    //{
    //    yield return new WaitForSeconds(delay);
    //    attackBlocked = false;
    //}
}
