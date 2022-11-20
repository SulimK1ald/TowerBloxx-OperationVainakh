using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visible : MonoBehaviour
{
    public bool onScreen = true;
    public GameOver deadScript;
    public float counter = 2f;
    public GameObject warningText;

    private void Start()
    {
        warningText.SetActive(false);
    }

    private void OnBecameVisible()
    {
        onScreen = true;
        warningText.SetActive(false);
    }
    private void OnBecameInvisible()
    {
        onScreen = false;
        warningText.SetActive(true);
    }

    public void DoCheck()
    {
        deadScript.StartGameOver();
        Time.timeScale = 0;
    }

    private void Update()
    {
        if (!onScreen)
        {
            counter -= Time.deltaTime;
        }
        else
        {
            counter = 2f;
        }

        if (counter < 0)
        {
            Invoke("DoCheck", 0f);
            counter = 2f;
        }
    }
}
