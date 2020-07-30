using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisapearingUI : MonoBehaviour
{
    MouseOver over;
    void Awake()
    {
        over = transform.parent.parent.gameObject.GetComponent<MouseOver>();
        Appear(false);
    }
    void OnMouseExit()
    {
        if (!over != null)
            if (over.mouseOver)
                return;
        Appear(false);
    }
    void OnMouseEnter()
    {
        Appear(true);
    }
    public void Appear(bool appear)
    {
        gameObject.GetComponent<Image>().enabled = appear;
        foreach (Image image in GetComponentsInChildren<Image>())
            image.enabled = appear;
    }
}
