using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class PlayerFire : MonoBehaviour
{
    SpriteRenderer spidermanSprite;
    AudioSource fireAudioSource;

    public Transform spawnPointLeft;
    public Transform spawnPointRight;

    public float projectileSpeed;
    public Projectile projectilePrefab;

    public AudioClip fireSFX;

    // Start is called before the first frame update
    void Start()
    {
        spidermanSprite = GetComponent<SpriteRenderer>();
        

        if (projectileSpeed <= 0)
            projectileSpeed = 7.0f;

        if (!spawnPointLeft || !spawnPointRight || !projectilePrefab)
            Debug.Log("Unity Inpector Values Not Set");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {

            FireProjectile();
            if (!fireAudioSource)
            {
                fireAudioSource = gameObject.AddComponent<AudioSource>();
                fireAudioSource.clip = fireSFX;
                fireAudioSource.loop = false;
                fireAudioSource.Play();
            }
            else
            {
                fireAudioSource.Play();
            }
        }
    }

    void FireProjectile()
    {
        if (spidermanSprite.flipX)
        {
            
            Projectile projectileInstance = Instantiate(projectilePrefab, spawnPointLeft.position, spawnPointLeft.rotation);
            projectileInstance.speed = -projectileSpeed;

        }
        else
        {
           
            Projectile projectileInstance = Instantiate(projectilePrefab, spawnPointRight.position, spawnPointRight.rotation);
            projectileInstance.speed = projectileSpeed;



        }


    }
}
