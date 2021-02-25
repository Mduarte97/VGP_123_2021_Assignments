using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{ 

public GameObject[] spawnPickUps;
public Transform[] spawnLocation;

    void Start ()
    {
        Instantiate(spawnPickUps[Random.Range(0, spawnPickUps.Length)], spawnLocation [Random.Range (0, spawnLocation.Length)]);
    }

    void Update()
    {
        
    }
}

