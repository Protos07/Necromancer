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

    public List<GameObject> AttackObject_List;
    private EnemyHealth cast_enemy_health;
    public GameObject AttackObject;
    private bool isFacingRight = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cast_enemy_health = GetComponent<EnemyHealth>();      
    }


    void Update()
    {
        
        if (isFollowObject == true && AttackObject_List != null)
        {
            Move();
            distance = Vector2.Distance(transform.position, AttackObject.transform.position);
        }            
        else
            GetObject();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {     
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Resurrection"))
        {
            AttackObject_List.Add(collision.gameObject);          
            
        }

    }

    public void OnTriggerExit2D(Collider2D collision)
    {      
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Resurrection"))
        {
            AttackObject_List.Remove(collision.gameObject);            
            if (AttackObject_List.Count == 0)
            {
                isFollowObject = false;
                AttackObject = null;
            }
            else
            {             
                GetObject();
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
        Debug.Log("hit");
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

    public void GetObject()
    {
        for(int i = 0; i < AttackObject_List.Count; i++)
        {
            if (AttackObject_List[i] != null)
            {             
                AttackObject = AttackObject_List[i];
                isFollowObject = true;
            }

        }
    }
}
