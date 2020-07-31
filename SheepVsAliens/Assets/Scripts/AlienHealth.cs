using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Keeps the health component 
public class AlienHealth : MonoBehaviour
{
    public int hp = 100;
    public float timeTilDustDisapear = 1f;
    public int moneyForDefeating;

    public TowerStats.DamageOverTime DoT = new TowerStats.DamageOverTime();
    //
    //  amount: what to decrease it by
    public void reduceHealth(int amount)
    {
        hp -= amount;
        StartCoroutine(redFlash());

        // Checks if enemie's health is zero
        if (hp <= 0)
        {
            // Gives player certian amount of money
            PlayerStats.changeMoneyAmount(moneyForDefeating);

            // Lessens one less enemie alive in the world
            --WaveSpawner.EnemiesAlive;

            SoundManager.PlaySound(SoundManager.Sound.CashPickup);

            SoundManager.PlaySound(SoundManager.Sound.AlienBeam);
            destroy(GameAssets.SpriteToGameObject(GameAssets.i.dustCloud)).transform.position = transform.position + new Vector3(gameObject.GetComponent<Collider2D>().offset.x, gameObject.GetComponent<Collider2D>().offset.y, 0);
            Destroy(gameObject);
        }
    }
    GameObject destroy(GameObject tobreak)
    {
        Destroy(tobreak, timeTilDustDisapear);
        return tobreak;
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        // Gets the FirePoint
        FirePoint firePoint = col.gameObject.GetComponent<FirePoint>();

        // Checks if has fire point
        if (firePoint != null)
        {
            // Lowers health by the projectile's damage
            reduceHealth(firePoint.damage);

            DoT.SetDoT(firePoint.dot);

            // Destroys projectile
            Destroy(col.gameObject);
        }
    }
    void Update()
    {
        if(DoT.DoTFullTime < DoT.DoTTime)
        {
            while(DoT.DoTCurrentTime >= 1f / DoT.DoT)
            {
                reduceHealth(1);
                DoT.DoTCurrentTime -= 1f / DoT.DoT;
            }
            DoT.DoTCurrentTime += Time.deltaTime;
            DoT.DoTFullTime += Time.deltaTime;
        }
        else
        {
            DoT.DoT = 0f;
        }
    }

    IEnumerator redFlash()
    {
        // adds a red material
        gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
        // waits for 0.1 secs (0.2 made it so the bees were causing the aliens to flash like horrible, possibly seizure-inducing christmas lights
        yield return new WaitForSeconds(0.1f);
        // returns the material to white
        gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.white);
    }
}
