using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endGameBehavoir : MonoBehaviour
{
    public playerInputHandler playermvoemtn;
    
    public void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            playermvoemtn.enabled = false;
            LevelManager.instance.winner();
        }
    }
}
