using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScene : MonoBehaviour
{
    public void RestLevel()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }

    public void MyYGpage()
    {
        Application.OpenURL("https://yandex.ru/games/developer?name=K1aldGames");
    }

    public void FlappyFlags()
    {
        Application.OpenURL("https://yandex.ru/games/developer?name=K1aldGames&app=171217");
    }
}
