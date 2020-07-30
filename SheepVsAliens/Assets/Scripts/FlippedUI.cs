using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlippedUi : MonoBehaviour

{
    MouseOver over;
    static FlippedUi display;

    float chickenTowerPos = GameObject.Find("chicken_coop").transform.position.y;
    float beeTowerPos = GameObject.Find("hive").transform.position.y;
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
        if (chickenTowerPos >= 1.9 || beeTowerPos >= 1.9)
            if (!DragHandler.dragHandler.isDragging || transform.name == "TowerUI" && display == null)
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