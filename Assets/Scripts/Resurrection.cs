using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resurrection : Enemy
{
    public float distance_toPlayer;

    public void Update()
    {
        if (distance_toPlayer <= distance)
        {
            Move();
        }


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
