using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurrentDrag : MonoBehaviour
{
    public GameObject turrent;
    Sprite turentSprite;

    void Start()
    {
        turentSprite = turrent.GetComponent<SpriteRenderer>().sprite;
        GetComponent<Image>().sprite = turentSprite;
    }
    public void GetTurrent()
    {
        if (!DragHandler.dragHandler.isDragging)
            DragHandler.dragHandler.SetHover(turrent);
    }
}
