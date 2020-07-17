using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameHandler : MonoBehaviour
{
    private static GameHandler instance;

    private LevelGrid levelGrid;

    private void Awake()
    {
        instance = this;
        Time.timeScale = 1f;
    }

    private void Start()
    {
        Debug.Log("GameHandler.Start");

        levelGrid = new LevelGrid(20, 20);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            if (IsGamePaused())
                GameHandler.ResumeGame();
            else
                GameHandler.PauseGame();
    }

    public static void ResumeGame()
    {
        PauseWindow.HideStatic();
        Time.timeScale = 1f;
    }

    public static void PauseGame()
    {
        PauseWindow.ShowStatic();
        Time.timeScale = 0f;
    }

    public static bool IsGamePaused()
    {
        return Time.timeScale == 0f;
    }
}
