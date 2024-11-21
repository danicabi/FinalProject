using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//CHANGES THE JUMP POWER OF PLAYER
public class yellowCapsuleBehvior : MonoBehaviour
{
    // Start is called before the first frame update
   float minJump = 5f;
    float maxJump = 30f;
    float duration = 5f;
    

    public void OnTriggerEnter2D(Collider2D other){
        pharmacist player = other.GetComponent<pharmacist>();
        if(other.CompareTag("Player") ){

            float randomJump = Random.Range(minJump, maxJump);
            player.ModifyJumpPowerTemporary(randomJump,duration);
            Destroy(gameObject);
            
        }
    }
}
