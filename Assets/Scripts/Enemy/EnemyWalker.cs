using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
public class EnemyWalker : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator anim;

    public AudioClip deathSFX;
    AudioSource deathAudioSource;

    public int health;
    public float speed;

    
    // Start is called before the first frame update
    void Start()
    {
       
        

       

        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        if (speed <= 0)
        {
            speed = 5.0f;

        }

        if (health <=0)
        {
            health = 3;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!anim.GetBool("death"))
        {


            if (sr.flipX)
            {
                rb.velocity = new Vector2(-speed, rb.velocity.y);

            }

            else
            {
                rb.velocity = new Vector2(speed, rb.velocity.y);
            }
        }
      

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Barrier")
        {
            sr.flipX = !sr.flipX;
        }
    }

    public void IsDead()

    {
        health--;
        if (health <= 0)
        {
            if (!deathAudioSource)
            {
                deathAudioSource = gameObject.AddComponent<AudioSource>();
                deathAudioSource.clip = deathSFX;
                deathAudioSource.loop = false;
                deathAudioSource.Play();
            }
            else
            {
                deathAudioSource.Play();
            }

            anim.SetBool("death", true);
            rb.velocity = Vector2.zero;

        
        }
    }

    public void FinishedDeath ()
    {
      

      
        Destroy(gameObject);
        GameManager.instance.score++;

    }

    
}
