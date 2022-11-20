using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public Sprite[] sprites;
    public SpriteRenderer SpR;

    public static Score instance;
    public bool canPlusScore;
    public int quantityCoins;

    [SerializeField] Text HighScoreText;
    [SerializeField] Text ScoreText;
    public int score;
    int highscore;
    Scene currentScene;

    private void Awake()
    {
        instance = this;
        currentScene = SceneManager.GetActiveScene();
    }
    private void Start()
    {
        instance = this;
        canPlusScore = true;
    }

    public void Count()
    {
        if (currentScene.name == "Scene1")
        {
            if (canPlusScore == true)
            {
                score = score + 1;
            }
            ScoreText.text = "Счёт: " + score.ToString();
        }
    }

    public void Record()
    {
        if (currentScene.name == "Scene1")
        {
            highscore = score;
            ScoreText.text = "Счёт: " + highscore.ToString();
            if (PlayerPrefs.GetInt("score") <= highscore)
                PlayerPrefs.SetInt("score", highscore);

            HighScoreText.text = "Рекорд: " + PlayerPrefs.GetInt("score").ToString();
        }
    }
}

