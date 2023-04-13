using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesController : MonoBehaviour
{
    GameObject playerGO;
    PlayerController playerScript;
    bool isObstacleUsed;


    void Start()
    {
        playerGO = GameObject.FindGameObjectWithTag("Player");
        playerScript = playerGO.GetComponent<PlayerController>();
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isObstacleUsed = true;
            playerScript.TouchedToObstacle();
            
        }
    }

}
