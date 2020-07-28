using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayWindow : MonoBehaviour
{
    private static GamePlayWindow instance;

    private void Awake()
    {
        instance = this;

    }

    private void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }

    public static void ShowStatic()
    {
        instance.Show();
    }

    public static void HideStatic()
    {
        instance.Hide();
    }

    public static Transform GetTransform()
    {
        return instance.gameObject.transform;
    }
}
