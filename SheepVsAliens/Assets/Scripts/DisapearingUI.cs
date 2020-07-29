using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisapearingUI : MonoBehaviour
{
    void OnMouseExit()
    {
        gameObject.GetComponent<Image>().enabled = false;
        foreach(Image image in GetComponentsInChildren<Image>())
            image.enabled = false;
    }
    void OnMouseEnter()
    {
        gameObject.GetComponent<Image>().enabled = true;
        foreach (Image image in GetComponentsInChildren<Image>())
            image.enabled = true;
    }
}
