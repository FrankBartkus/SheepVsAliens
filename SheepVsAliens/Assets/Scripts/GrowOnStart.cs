using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class GrowOnStart : MonoBehaviour
{
    TowerStats stats;
    public float speed = 10f;
    float area;
    float radius;
    // Start is called before the first frame update
    void Awake()
    {
        stats = transform.parent.gameObject.GetComponent<TowerStats>();
        transform.localScale = Vector3.zero;
        area = 0;
        radius = 0;
    }
    // Update is called once per frame
    void Update()
    {
        if (stats.fireCountdown == stats.fireRate)
        {
            foreach (AlienHealth alienHealth in GameObject.FindObjectsOfType<AlienHealth>())
                if (Vector2.Distance(alienHealth.gameObject.transform.position, transform.position) <= radius)
                    alienHealth.reduceHealth(stats.damage);
            stats.fireCountdown = 0f;
        }
        else
            stats.fireCountdown = Mathf.Clamp(stats.fireCountdown + Time.deltaTime, 0f, stats.fireRate);
        if (radius == stats.range)
            return;
        area += speed * Time.deltaTime;
        radius = Mathf.Clamp(Mathf.Sqrt(area / Mathf.PI), 0f, stats.range); 
        transform.localScale = new Vector3(radius * 2f, radius * 2f, transform.localScale.z);
    }
}
