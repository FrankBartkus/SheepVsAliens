using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienHealth : MonoBehaviour
{
    public float hp = 100f;
    

    public void reduceHealth(float amount)
    {
        hp -= amount;
        if (hp <= 0) Destroy(gameObject);
    }
}
