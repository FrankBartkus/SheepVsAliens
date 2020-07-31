using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class GrowOnStart : MonoBehaviour
{
    TowerStats stats;
    GameObject tower;
    Vector3 offset;
    public float speed = 10f;
    public float turnSpeed = 10f;
    AudioSource beesAmbiance;
    float area;
    float radius;
    float angle = 0f;
    // Start is called before the first frame update
    void Awake()
    {
        stats = transform.parent.gameObject.GetComponent<TowerStats>();
        offset = transform.parent.position;
        tower = transform.parent.gameObject;
        area = 0;
        radius = 0;
        SoundManager.LoopSound(SoundManager.Sound.AttackBee);
        foreach (AudioSource audio in FindObjectsOfType<AudioSource>())
            if (audio.clip == SoundManager.GetAudioClip(SoundManager.Sound.AttackBee))
                beesAmbiance = audio;
    }
    // Update is called once per frame
    void Update()
    {
        if(beesAmbiance != null)
        {
            if(!GameHandler.IsGamePaused())
            {
                if (beesAmbiance.isPlaying)
                {
                    if (!anyInRange())
                        beesAmbiance.Pause();
                }
                else if (anyInRange())
                    beesAmbiance.UnPause();
            }
        }
        if (stats.fireCountdown == stats.fireRate)
        {
            foreach (AlienHealth alienHealth in GameObject.FindObjectsOfType<AlienHealth>())
                if (Vector2.Distance(alienHealth.gameObject.transform.position, transform.parent.position) <= radius)
                    alienHealth.reduceHealth(stats.damage);
            stats.fireCountdown = 0f;
        }
        else
            stats.fireCountdown = Mathf.Clamp(stats.fireCountdown + Time.deltaTime, 0f, stats.fireRate);
        if (radius != stats.range)
        {
            area += speed * Time.deltaTime;
            radius = Mathf.Clamp(Mathf.Sqrt(area / Mathf.PI), 0f, stats.range);
        }
        angle += turnSpeed * Time.deltaTime / radius;
        transform.position = offset + new Vector3(radius * Mathf.Cos(angle), radius * Mathf.Sin(angle), 0);
        transform.rotation = Quaternion.Euler(0, 0, (angle * Mathf.Rad2Deg));
    }
    bool anyInRange()
    {
        foreach (AlienHealth alienHealth in GameObject.FindObjectsOfType<AlienHealth>())
            if (Vector2.Distance(alienHealth.gameObject.transform.position, transform.position) <= radius)
                return true;
        return false;
    }
}
