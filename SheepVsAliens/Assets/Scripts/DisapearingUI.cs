using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisapearingUI : MonoBehaviour
{
    MouseOver over;
    static DisapearingUI display;
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
        if(!DragHandler.dragHandler.isDragging || transform.name == "TowerUI" && display == null)
            Appear(true);
    }
    public void Appear(bool appear)
    {
        if (appear)
            display = this;
        else
            display = null;
        gameObject.GetComponent<Image>().enabled = appear;
        foreach (Image image in GetComponentsInChildren<Image>())
            image.enabled = appear;
    }
}
