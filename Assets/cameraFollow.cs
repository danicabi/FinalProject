using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    [SerializeField] Transform playerTransform;

    // Update is called once per frame
    void Update()
    {
        if(playerTransform != null){
            
            transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y, -10);

        }
    }
}