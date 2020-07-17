using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public Transform baseAlien;

    public float timeBetweenWaves = 10f;
    private float countdown = 5f;
    public int wave = 1;

    private void Start()
    {
        SpawnWave();
        wave++;
        countdown = timeBetweenWaves;
    }

    void Update()
    {
        if (countdown <= 0f)
        {
            SpawnWave();
            countdown = timeBetweenWaves;
            wave++;
        }
        countdown -= Time.deltaTime;
    }

    void SpawnWave()
    {
        Debug.Log("Wave " + wave + " Incomming!");
        
    }
}
