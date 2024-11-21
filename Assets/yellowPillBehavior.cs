using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//CHANGES DASH POWER OF PLAYER
public class yellowPillBehavior : MonoBehaviour
{
   float minDash = 10f;
    float maxDash = 50f;
    float duration = 5f;
    

    public void OnTriggerEnter2D(Collider2D other){
        pharmacist player = other.GetComponent<pharmacist>();
        if(other.CompareTag("Player") ){

            float randomDash = Random.Range(minDash, maxDash);
            player.ModifyDashPowerTemporary(randomDash,duration);
            Destroy(gameObject);
            
        }
    }
}
