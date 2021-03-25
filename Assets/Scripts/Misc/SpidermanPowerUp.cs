using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpidermanPowerUp : MonoBehaviour
{
    public enum CollectibleType
    {
        POWERUP,
        COLLECTIBLE,
        LIVES,
        KEY,
        POWERUPWEBSHOT
    }

    public CollectibleType currentcollectible;
    public AudioClip collisionClip;
    AudioSource pickupAudio;
    BoxCollider2D trigger;

    private void Start()
    {
        pickupAudio = GetComponent<AudioSource>();
        trigger = GetComponent<BoxCollider2D>();
        if (pickupAudio)
        {
            pickupAudio.loop = false;
            pickupAudio.clip = collisionClip;
        }
    }

    private void Update()
    {
        if (!pickupAudio.isPlaying && !trigger.enabled)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && GameManager.instance.playerInstance)
        {
            switch (currentcollectible)
            {
                case CollectibleType.COLLECTIBLE:
                    Debug.Log("Collectible");
                    GameManager.instance.score++;
                    pickupAudio.Play();
                    trigger.enabled = false;
                    break;

                case CollectibleType.LIVES:
                    Debug.Log("Lives");
                    GameManager.instance.lives++;
                    
                    pickupAudio.Play();
                    trigger.enabled = false;
                   
                    break;

                case CollectibleType.POWERUP:
                    collision.GetComponent<PlayerMovement>(). StartJumpForceChange();
                    
                    pickupAudio.Play();
                    trigger.enabled = false;
                     
                    Debug.Log("PowerUp");
                    break;


                case CollectibleType.POWERUPWEBSHOT:
                    collision.GetComponent<PlayerMovement>();
                     
                    pickupAudio.Play();
                    trigger.enabled = false;
                    Debug.Log("PowerUpWebshot");
                    break;

                case CollectibleType.KEY:
                    collision.GetComponent<PlayerMovement>();
                    pickupAudio.Play();
                    trigger.enabled = false;
                    Debug.Log("key");
                    break;



            }
        }

       
    }
}
