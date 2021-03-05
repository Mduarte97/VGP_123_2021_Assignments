using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]

public class EnemyTurret : MonoBehaviour
{


    SpriteRenderer enemyTurretSprite;
    public Transform spawnPointLeft;
    public Transform spawnPointRight;
    public Transform projectileSpawnPoint;
    public Projectile projectilePrefab;

    public bool isFacingRight;
    public Transform Player;
    public float distance;
   
    public float projectileSpeed;
    public float projectileForce;

    public float projectileFireRate;
    float timeSinceLastFire = 0.0f;
    public int health;

    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        if (projectileForce <=0)
        {
            projectileForce = 7.0f;
        }

        if (health <= 0)
        {
            health = 5;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(transform.position, Player.transform.position);
        Debug.Log(distance);
        if (Time.time >= timeSinceLastFire + projectileFireRate && distance <=50)
        {
            anim.SetBool("Fire", true);
            timeSinceLastFire = Time.time;
        }

        if (transform.position.x < Player.position.x && !isFacingRight)
        {
            flip();

        }
        else if (transform.position.x > Player.position.x && isFacingRight)
        {
            flip();

        }


        if (Time.time > timeSinceLastFire + projectileFireRate && distance <= 50)
        {
            Fire();
            timeSinceLastFire = Time.time;
        }



        void flip()
        {
            if (isFacingRight)
                isFacingRight = false;
            else
                isFacingRight = true;

            Vector3 scaleFactor = transform.localScale;

            scaleFactor.x *= -1;


            transform.localScale = scaleFactor;
        }
    }

    public void Fire()
    {

        if (isFacingRight == true)
        {
            Projectile temp = Instantiate(projectilePrefab, spawnPointLeft.position, spawnPointLeft.rotation);
            temp.speed = projectileForce;
        }
        else 
        {
            Projectile temp = Instantiate(projectilePrefab, spawnPointLeft.position, spawnPointLeft.rotation);
            temp.speed = -projectileForce;
        }
    }

    public void ReturnToIdle()
    {
        anim.SetBool("Fire", false);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "SpidermanProjectile")
        {
            health--;
            Destroy(collision.gameObject);

            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

   
    
    }
