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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            switch (currentcollectible)
            {
                case CollectibleType.COLLECTIBLE:
                    Debug.Log("Collectible");
                    collision.GetComponent<PlayerMovement>().score++;
                    Destroy(gameObject);
                    break;

                case CollectibleType.LIVES:
                    Debug.Log("Lives");
                    collision.GetComponent<PlayerMovement>().lives++;
                    Destroy(gameObject);
                    break;

                case CollectibleType.POWERUP:
                    collision.GetComponent<PlayerMovement>
                        ().StartJumpForceChange();
                    Destroy(gameObject);
                    Debug.Log("PowerUp");
                    break;


                case CollectibleType.POWERUPWEBSHOT:
                    collision.GetComponent<PlayerMovement>();
                    Destroy(gameObject);
                    Debug.Log("PowerUpWebshot");
                    break;

                case CollectibleType.KEY:
                    collision.GetComponent<PlayerMovement>();
                    Debug.Log("key");
                    break;



            }
        }

       
    }
}
