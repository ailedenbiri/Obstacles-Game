using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    public Transform target;
    public Vector3 offSet;
    void Start()
    {
        
    }

    
    void LateUpdate()
    {
        if (target != null)
        {
            transform.position = target.position + offSet;
        }
       
    }
}
