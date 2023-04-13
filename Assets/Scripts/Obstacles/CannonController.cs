using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CannonController : MonoBehaviour
{

    public GameObject cannonGO;
    public Transform cannonBallSpawnTransform;
    private float cannonBallSpeed = 13f;
    bool isShootingOn;


    void Start()
    {
        isShootingOn = (true);
        StartCoroutine(Shooting());
        
    }

    
    void Update()
    {
        
    }
    IEnumerator Shooting()
    {
        float delayTime = Random.Range(0.5f, 1.5f);
        while (isShootingOn) 
        {
            yield return new WaitForSeconds(delayTime);
            shoot();
            yield return new WaitForSeconds(1.5f);
        }
    }
    private void shoot ()
    {
        GameObject cannonball = Instantiate(cannonGO, cannonBallSpawnTransform.position, Quaternion.identity);
        Rigidbody cannonRB = cannonball.GetComponent<Rigidbody>();
        cannonRB.velocity = -transform.forward * cannonBallSpeed;
    }


}








