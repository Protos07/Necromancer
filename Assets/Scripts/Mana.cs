using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mana : MonoBehaviour
{
   
    public float Mana_value;
    public float maxMana;
    public Slider mana_bar;
    public Slider mana_fill_bar;
    [SerializeField] public float _damage;   

    public float speed;

    void Start()
    {
        if (mana_bar.value != Mana_value)
        {
            mana_bar.value = Mana_value;
        }
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            

        }
        mana_fill_bar.value = Mathf.Lerp(mana_fill_bar.value, mana_bar.value, speed);
    }

}
