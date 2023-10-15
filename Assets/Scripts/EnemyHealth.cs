using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health
{

    public void Update()
    {        
        health_bar_fill.value = Mathf.Lerp(health_bar_fill.value, health_bar.value, speed);
             
        if (health_bar.value == 0)
        {
            Debug.Log("You killed him!");
            Destroy(this.gameObject);
        }
    }
}
