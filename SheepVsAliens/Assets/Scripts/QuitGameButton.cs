using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGameButton : MonoBehaviour
{
    // Start is called before the first frame update
  
    
    void OnMouseOver()
    {
       if(Input.GetMouseButtonDown(0))
        {
            Application.Quit();
        }
    }

    
}
