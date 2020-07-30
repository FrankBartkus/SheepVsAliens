using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewLevel : MonoBehaviour
{
    public void newLevel(string level)
    {
        SceneManager.LoadScene(level);
    }
    public void newLevel(int level)
    {
        SceneManager.LoadScene(level);
    }
}
