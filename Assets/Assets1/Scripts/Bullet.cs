using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public Vector2 offset;
    public float deathTime = 0.5f;
    public int damage = 1;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            enemy.TakeDamage(damage);
        }
        if (collision.otherCollider)
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        offset = transform.right * speed * Time.deltaTime;
        rb.MovePosition(rb.position + offset);
    }
}
