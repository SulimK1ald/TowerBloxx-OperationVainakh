using UnityEngine;
using UnityEngine.SceneManagement;

public class EnableHero : MonoBehaviour
{
    public GameObject spriteOfHero;
    public GameObject player;

    void Start()
    {
        spriteOfHero.SetActive(true);
        player.SetActive(true);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "heroTag")
        {
            SceneManager.LoadScene("Win");
        }
    }
}
