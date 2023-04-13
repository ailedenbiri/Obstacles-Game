using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondController : MonoBehaviour
{
    GameObject playerGO;
    PlayerController playerScript;

    bool isItCollected;
    
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
            isItCollected = true;
            playerScript.TouchedToDiamond();
            Destroy(gameObject);
        }
    }


}
