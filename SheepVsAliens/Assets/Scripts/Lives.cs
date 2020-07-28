using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lives : MonoBehaviour
{
    public static Lives i;

    public int lives = 5;
    Transform liveParent;

    void Awake()
    {
        i = this;
        liveParent = GameObject.Find("Lives").transform;
    }

    
}
