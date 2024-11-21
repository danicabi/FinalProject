using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//CHANGES TIME OF DASH
public class redPillBehavior : MonoBehaviour
{
    float minTime = .1f;
    float maxTime = 1;
    float duration = 5f;
    

    public void OnTriggerEnter2D(Collider2D other){
        pharmacist player = other.GetComponent<pharmacist>();
        if(other.CompareTag("Player") ){

            float randomDashTime = Random.Range(minTime, maxTime);
            player.ModifyDashTimeTemporary(randomDashTime,duration);
            Destroy(gameObject);
            
        }
    }
}
