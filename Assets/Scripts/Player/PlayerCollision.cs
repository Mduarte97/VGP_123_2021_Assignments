using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerCollision : MonoBehaviour
{
    Rigidbody2D rb;
    PlayerMovement pm;

    public float bounceForce;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pm = GetComponent<PlayerMovement>();

        if (bounceForce <= 0)
        {
            bounceForce = 3500.0f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Squished")
        {
            if (!pm.isGrounded)
            {
                collision.gameObject.GetComponentInParent<EnemyWalker>().IsDead();
                rb.velocity = Vector2.zero;
                rb.AddForce(Vector2.up * bounceForce);

            }
        }
    }
}
