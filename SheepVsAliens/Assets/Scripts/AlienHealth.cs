using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienHealth : MonoBehaviour
{
    public int hp = 100;
    public int moneyForDefeating;

    public void reduceHealth(int amount)
    {
        hp -= amount;
        if (hp <= 0)
        {
            PlayerStats.changeMoneyAmount(moneyForDefeating);
            --WaveSpawner.EnemiesAlive;
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        FirePoint firePoint = col.gameObject.GetComponent<FirePoint>();
        if (firePoint != null)
        {
            reduceHealth(firePoint.damage);
            Destroy(col.gameObject);
        }
    }
}
