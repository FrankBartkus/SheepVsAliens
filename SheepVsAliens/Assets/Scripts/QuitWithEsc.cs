using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitWithEsc : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //There's not anything in the start function to do. I mean, is the average player gonna throw a hissy fit that they can't exit the 
    }

    // Update is called once per frame
    void Update()
    {
        //Now we can actually start quitting the game! We're gonna have it so you press ESC to quit.
        //Do keep in mind that this code will NOT work without building the scene first.
        //Pressing ESC while just running it will do nothing.

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        //That makes it so pressing ESC quits the application (aka the game).
    }
}
