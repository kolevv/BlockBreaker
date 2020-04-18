using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void LoadLevel(string name)
    {
        Debug.Log("Level load requested for " + name);
        Brick.breakableCount = 0;
        SceneManager.LoadScene(name);
    
    }


    public void QuitRequest()
    {
        Debug.Log("Quit request");
        Application.Quit();
    }

    public void LoadNextLevel()
    {
        Brick.breakableCount = 0;
        int nextLevelIndex = SceneManager.GetActiveScene().buildIndex +1;
        PlayerPrefs.SetInt("LastLevel", nextLevelIndex);
        SceneManager.LoadScene(nextLevelIndex);
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("LastLevel"));
        print("Level reload requested for level: " + PlayerPrefs.GetInt("LastLevel"));
    }

    public void BrickDestroyed()
    {
        if (Brick.breakableCount <= 0)
        {
            LoadNextLevel();
        }
    }
}


