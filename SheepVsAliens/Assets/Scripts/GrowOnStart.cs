using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class GrowOnStart : MonoBehaviour
{
    public float speed = 10f;
    public float maxRange = 10f;
    public float timerMax = 0.1f;
    public int damage = 10;
    float timer = 0f;
    float area;
    float radius;
    // Start is called before the first frame update
    void Awake()
    {
        transform.localScale = Vector3.zero;
        timer = timerMax;
        area = 0;
        radius = 0;
    }
    // Update is called once per frame
    void Update()
    {
        if (timer == timerMax)
        {
            foreach (AlienHealth alienHealth in GameObject.FindObjectsOfType<AlienHealth>())
                if (Vector2.Distance(alienHealth.gameObject.transform.position, transform.position) <= radius)
                    alienHealth.reduceHealth(damage);
            timer = 0f;
        }
        else
            timer = Mathf.Clamp(timer + Time.deltaTime, 0f, timerMax);
        if (radius == maxRange)
            return;
        area += speed * Time.deltaTime;
        radius = Mathf.Clamp(Mathf.Sqrt(area / Mathf.PI), 0f, maxRange); 
        transform.localScale = new Vector3(radius * 2f, radius * 2f, transform.localScale.z);
    }
}
