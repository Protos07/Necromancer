using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : MonoBehaviour
{
    public LayerMask enemies;
    public GameObject player;
    public float range;
    public GameObject Resurrection_object;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Resurrection()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(player.transform.position, range, enemies);
        foreach (Collider2D enemy in hitEnemies)
        {
            EnemyHealth cast_enemyHealth = enemy.GetComponent<EnemyHealth>();
            if (cast_enemyHealth.health_bar.value == 0)
            {
                Destroy(enemy);
                Instantiate(Resurrection_object, enemy.transform.position, enemy.transform.rotation);

                Debug.Log("work");
            }

        }
    }
}
