using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePoint : MonoBehaviour
{
    public float speed;
    public float damage;
    public static float timeTilDeath = 10f;
    float timeAlive = 0f;

    public void Fire(GameObject target)
    {
        gameObject.AddComponent<Rigidbody2D>().velocity = speed * (target.transform.position - transform.position).normalized;
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 0f;
    }
    void Update()
    {
        if (timeAlive < timeTilDeath)
            timeAlive += Time.deltaTime;
        else
            Destroy(gameObject);
    }

}
