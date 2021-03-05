using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player)
        {
            Vector3 cameraTransform;
            cameraTransform = transform.position;
            cameraTransform.x = player.transform.position.x - 0.163f;
            cameraTransform.x = Mathf.Clamp(cameraTransform.x, 0, 1021f);
            cameraTransform.y = player.transform.position.y ;

            transform.position = cameraTransform;
        }
    }
}
