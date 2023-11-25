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
    public GameObject Dead_obj;

    public float speed;
    public Vector3 current_transform;
    public Canvas canvas;

    private MainMenu cast_mainmenu;

    void Start()
    {
        cast_mainmenu = canvas.GetComponent<MainMenu>();
        if (health_bar.value != health)
        {
            health_bar.value = health;
        }

        _damage = (Random.Range(min_damage, max_damage));
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ApplyDamage(_damage = (Random.Range(min_damage, max_damage)));

        }
        if (health_bar.value != health)
        {
            health_bar.value += 0.03f * Time.deltaTime;
        }
        health_bar_fill.value = Mathf.Lerp(health_bar_fill.value, health_bar.value, speed);

        if (health_bar.value <= 0.08)
            Dead();
    }

    public void ApplyDamage(float damage)
    {       
        health_bar.value -= damage;       
    }

    public void Dead()
    {
        current_transform = new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z);
        Instantiate(Dead_obj, current_transform, transform.rotation);
        cast_mainmenu.main.SetActive(false);
        cast_mainmenu.Dead.SetActive(true);
        Destroy(this.gameObject);
    }

   
}
