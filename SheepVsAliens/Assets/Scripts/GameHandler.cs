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
        SoundManager.LoopSound(SoundManager.Sound.LevelTheme);
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
        foreach (AudioSource audio in FindObjectsOfType<AudioSource>())
        {
            audio.UnPause();
        }
        SoundManager.PlaySound(SoundManager.Sound.Unpause);
        Time.timeScale = 1f;
    }

    public static void PauseGame()
    {
        PauseWindow.ShowStatic();
        foreach (AudioSource audio in FindObjectsOfType<AudioSource>())
            audio.Pause();
        SoundManager.PlaySound(SoundManager.Sound.Pause);
        Time.timeScale = 0f;
    }

    public static bool IsGamePaused()
    {
        return Time.timeScale == 0f;
    }

    public static void GameOverLevel()
    {
        GameOverWindow.ShowStatic();
        GameWindow.HideStatic();
        foreach (AudioSource audio in FindObjectsOfType<AudioSource>())
            Destroy(audio.gameObject);
        Time.timeScale = 0f;
    }
    public static void WinLevel()
    {
        GameOverWindow.ShowStatic();
        GameWindow.HideStatic();
        foreach (AudioSource audio in FindObjectsOfType<AudioSource>())
            Destroy(audio.gameObject);
        Time.timeScale = 0f;
    }
}
