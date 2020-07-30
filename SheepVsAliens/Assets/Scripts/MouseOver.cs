using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseOver : MonoBehaviour
{
    [HideInInspector]
    public bool mouseOver = false;
    DisapearingUI ui;

    void Awake()
    {
        ui = GetComponentInChildren<DisapearingUI>();
    }
    void OnMouseEnter()
    {   
        if(ui != null)
            ui.Appear(true);
        if(!mouseOver)
        {
            SoundManager.PlaySound(SoundManager.Sound.ButtonOver);
            mouseOver = true;
        }
    }
    void OnMouseExit()
    {
        mouseOver = false;
        if (ui != null)
            ui.Appear(false);
    }
}
