using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisapearingUI : MonoBehaviour
{
    public bool col;
    void OnMouseExit()
    {
        col = false;
        gameObject.SetActive(false);
    }
    void OnMouseEnter()
    {
        col = true;
    }
}
