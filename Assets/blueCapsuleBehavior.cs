using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//CHAGES SPEED OF PROJECTILE
public class blueCapsuleBehavior : MonoBehaviour
{
    //[SerializeField] projectileLauncher gun;
    float minSpeed = 5f;
    float maxSpeed = 50;
    float duration = 5f;
    

    public void OnTriggerEnter2D(Collider2D other){
        projectileLauncher gun = other.GetComponent<projectileLauncher>();
        if(other.CompareTag("Player") ){

            float randomSpeed = Random.Range(minSpeed, maxSpeed);
            gun.ModifySpeedTemporary(randomSpeed,duration);
            Destroy(gameObject);
            
        }
    }
}
