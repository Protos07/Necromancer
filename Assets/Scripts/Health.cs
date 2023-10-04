using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public Slider health_bar;
    public Slider health_bar_fill;
    [SerializeField]public float _damage;
    public float max_damage;
    public float min_damage;

    public float speed;

    void Start()
    {
        if (health_bar.value != health)
        {
            health_bar.value = health;
        }
        
        
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ApplyDamage(_damage);

        }
        //FIX IT!!!!
        _damage = (Random.Range(min_damage, max_damage));
        //
        health_bar_fill.value = Mathf.Lerp(health_bar_fill.value, health_bar.value, speed);
    }

    public void ApplyDamage(float damage)
    {       
        health_bar.value -= damage;       
    }

}
