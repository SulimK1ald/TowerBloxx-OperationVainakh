using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    private float moveInput;
    private float moveInputByJoystick;
    public float speed = 5;
    public float jumpForce;
    public bool isGrounded;
    public Transform feetPos;
    public int coins;
    public Text coinsText;
    public GameOver deadScript;
    public Score moneyScript;

    public Joystick joystick;
    public bool Keyboard = false;
    public bool isJumping = false;
    public Rotater rotaterScript;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (Application.isMobilePlatform)
        {
            Debug.Log("Android(not PC)");
            Keyboard = false;
        }
        else
        {
            Debug.Log("PC");
            Keyboard = true;
        }
    }

    void FixedUpdate()
    {
        if (Keyboard)
        {
            rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
            moveInput = Input.GetAxis("Horizontal");
        }
        else
        {
            rb.velocity = new Vector2(moveInputByJoystick * speed, rb.velocity.y);
            moveInputByJoystick = joystick.Horizontal;
        }
    }

    private void Update()
    {
        CheckGround();
        if (isGrounded == true && Input.GetKey(KeyCode.W) && isJumping == false)
        {
            rb.velocity = Vector2.up * jumpForce;
            StartCoroutine(JumpTime());
        }
    }
    public void jumpBtn()
    {
        if (isGrounded == true && isJumping == false)
        {
            rb.velocity = Vector2.up * jumpForce;
            StartCoroutine(JumpTime());
        }
    }
    IEnumerator JumpTime()
    {
        isJumping = !isJumping;
        yield return new WaitForSeconds(1.2f);
        isJumping = !isJumping;
        StopCoroutine(JumpTime());
    }

    void CheckGround()
    {
        Collider2D[] playerOnTheGround = Physics2D.OverlapCircleAll(feetPos.position, 0.25f);
        isGrounded = playerOnTheGround.Length > 1;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            deadScript.StartGameOver();
            Time.timeScale = 0;
        }
    }
}
