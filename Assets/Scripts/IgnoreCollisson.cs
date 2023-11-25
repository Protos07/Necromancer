using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollisson : MonoBehaviour
{

    void Start()
    {
        Physics2D.IgnoreLayerCollision(8,9);
        Physics2D.IgnoreLayerCollision(10,9);
        Physics2D.IgnoreLayerCollision(10,7);

    }

    
}
