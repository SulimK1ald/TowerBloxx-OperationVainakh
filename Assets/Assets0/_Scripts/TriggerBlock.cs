using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TriggerBlock : MonoBehaviour
{
    public float timeWait;
    public Text scoreText;
    public Rigidbody2D craneRb;
    public Transform followCamPos;
    bool didFirstCollision = false;
    public GameOver deadScript;
    public GameObject effect;

    //public Animator camShake;

    private void Start()
    {
        deadScript = FindObjectOfType<GameOver>();
        //camShake = FindObjectOfType<Animator>();
        Time.timeScale = 1;
    }

    /*public void Shake()
    {
        camShake.SetTrigger("shake");
    }*/

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!didFirstCollision && collision.gameObject.tag == "Collide")
        {
            //Shake();
            Instantiate(effect, transform.position, Quaternion.identity);
            didFirstCollision = true;
            Rotater.instance.TryMoveHigher(transform.position);
            Score.instance.Count();
        }

        if (collision.gameObject.tag == "Enemy")
        {
            deadScript.StartGameOver();
            Time.timeScale = 0;
        }
    }
}
