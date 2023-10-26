using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health
{
<<<<<<< HEAD
    private Collider2D col;
    public Enemy enemy_cast;
    public Transform player;
    public void Start()
    {
        enemy_cast = GetComponent<Enemy>();
        col = GetComponent<Collider2D>();

    }
=======

>>>>>>> parent of c6c0653 (fixed ui)
    public void Update()
    {        
        health_bar_fill.value = Mathf.Lerp(health_bar_fill.value, health_bar.value, speed);
             
        if (health_bar.value == 0)
        {
<<<<<<< HEAD
            Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), col);
            enemy_cast.enabled = false;
            
=======
            Debug.Log("You killed him!");
            Destroy(this.gameObject);
>>>>>>> parent of c6c0653 (fixed ui)
        }
    }
}
