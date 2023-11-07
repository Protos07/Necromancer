using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health
{
    private Collider2D col;
    public Enemy enemy_cast;
    public Transform player;

    private Rigidbody2D rb;
    public void Start()
    {
        enemy_cast = GetComponent<Enemy>();
        col = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
    }
    public void Update()
    {        
        health_bar_fill.value = Mathf.Lerp(health_bar_fill.value, health_bar.value, speed);
             
        if (health_bar.value == 0)
        {
            col.isTrigger = true;
            Destroy(rb);
            if (this.gameObject.CompareTag("Resurrection"))
            {
                Destroy(this.gameObject);              
            }
                
            enemy_cast.enabled = false;
           
        }
    }
}
