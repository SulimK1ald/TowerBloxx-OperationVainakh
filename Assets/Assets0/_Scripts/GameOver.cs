using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject deadPanel;
    public Rotater RotateScript;
    public Score scoreCount;

    Scene currentScene;


    private void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        deadPanel.SetActive(false);
        scoreCount = FindObjectOfType<Score>();
        RotateScript = FindObjectOfType<Rotater>();
    }

    public void StartGameOver()
    {
        RotateScript.over = true;
        if (currentScene.name == "Map2")
        {
            RotateScript.spawnButton.SetActive(false);
            RotateScript.spawnButton2.SetActive(false);
            RotateScript.joysButton.SetActive(false);
            RotateScript.jumpButton.SetActive(false);
        }
        else if (currentScene.name == "Scene1")
        {
            RotateScript.spawnButton.SetActive(false);
        }
        scoreCount.Record();
        deadPanel.SetActive(true);
        RotateScript.numberOfBlocks = 0;
        scoreCount.canPlusScore = false;
    }
}
