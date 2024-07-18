using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void EndScreen()
    {
        SceneManager.LoadSceneAsync(2);
    }

    public void GameOver()
    {
        SceneManager.LoadSceneAsync(3);
    }

    public void HiddenScreen()
    {
        SceneManager.LoadSceneAsync(4);
    }
}
