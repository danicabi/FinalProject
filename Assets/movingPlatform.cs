using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Scripting.APIUpdating;

public class movingPlatform : MonoBehaviour
{
    [SerializeField] Transform pointA;
    [SerializeField] Transform pointB;
    float moveSpeed = 2f;
    Vector3 nextPos;
    public bool start = false;
    void Start()
    {
        nextPos = pointB.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(start){
            
           transform.position = Vector3.MoveTowards(transform.position,nextPos, moveSpeed * Time.deltaTime);

            if(transform.position == nextPos){
            nextPos = (nextPos == pointA.position)?pointB.position : pointA.position;
        } 
        }

        
    }

}
