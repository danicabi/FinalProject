using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//CHANGES SPEED OF PLAYER
public class purpeCapsuleBehavior : MonoBehaviour
{
    //[SerializeField] pharmacist player;
    float minSpeed = 5f;
    float maxSpeed = 30f;
    float duration = 5f;
    

    public void OnTriggerEnter2D(Collider2D other){
        pharmacist player = other.GetComponent<pharmacist>();
        if(other.CompareTag("Player") ){

            float randomSpeed = Random.Range(minSpeed, maxSpeed);
            player.ModifySpeedTemporary(randomSpeed,duration);
            Destroy(gameObject);
            
        }
    }
    
}
