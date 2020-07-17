using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lives : MonoBehaviour
{
    public static float lives = 10f;

    public static void reduceLives(float amount)
    {
        lives -= amount;
        if (lives <= 0)
        {
            lives = 0;
            //Game is over
            throw new System.Exception("Game Over!");
        }
    }
    
}
