using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseOver : MonoBehaviour
{
    [HideInInspector]
    public bool mouseOver = false;

    void OnMouseOver()
    {
        if(!mouseOver)
        {
            SoundManager.PlaySound(SoundManager.Sound.ButtonOver);
            mouseOver = true;
        }
    }
    void OnMouseExit()
    {
        mouseOver = false;
    }
}
