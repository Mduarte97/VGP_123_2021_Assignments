using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpidermanPowerUp : MonoBehaviour
{
<<<<<<< Updated upstream
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D collision)
=======
    private GameObject collectible;
    public enum CollectibleType
>>>>>>> Stashed changes
    {
        if (collision.gameObject.name == "Player")
        {
<<<<<<< Updated upstream
            Destroy(gameObject);
            Debug.Log("hello");
=======
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
                    Debug.Log("Key");
                    break;

            }
>>>>>>> Stashed changes
        }


    }

<<<<<<< Updated upstream
=======
   

>>>>>>> Stashed changes
}
