using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySoundOnStop : MonoBehaviour
{
    AudioSource audio;
    bool start = false;
    // Start is called before the first frame update
    void Start()
    {
        audio = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!start)
        {
            start = true;
            return;
        }
        if (Time.timeScale > 0f)
            if(!audio.isPlaying)
                Destroy(gameObject);
    }
}
