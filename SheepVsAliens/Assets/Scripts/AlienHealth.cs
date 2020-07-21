using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienHealth : MonoBehaviour
{
    public float hp = 100f;
    

    public void reduceHealth(float amount)
    {
        hp -= amount;
        if (hp <= 0) 
            Destroy(gameObject);
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        UnityEngine.Debug.Log("Hit");
        FirePoint firePoint = col.gameObject.GetComponent<FirePoint>();
        if (firePoint != null)
        {
            UnityEngine.Debug.Log("Hit");
            reduceHealth(firePoint.damage);
            Destroy(col.gameObject);
        }
    }
}
