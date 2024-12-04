using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//GIVE THE PLAYER HEALTH
public class orageCapsuleBehavior : MonoBehaviour
{
   
    

    public void OnTriggerEnter2D(Collider2D other){
        pharmacist player = other.GetComponent<pharmacist>();
        if(other.CompareTag("Player") ){

            player.setandcheckHealth(player.currentHealth + 1);
            Destroy(gameObject);
            
        }
    }
}
