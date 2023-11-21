using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class EnemyHealth : Health
{
    private Collider2D col;
    public Enemy enemy_cast;
    public Transform player;
    public Ability abil;

    private GameObject abil_object;
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
            if (this.gameObject.CompareTag("Enemy"))
            {
                this.gameObject.tag = "Dead";
            }
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
