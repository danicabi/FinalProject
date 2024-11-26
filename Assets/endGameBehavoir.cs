using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Unity.VisualScripting;
using UnityEngine;

public class endGameBehavoir : MonoBehaviour
{
    public playerInputHandler playermvoemtn;
    bool allowOpen;

    public void Update(){
        if(allowOpen && Input.GetKeyDown(KeyCode.E)){
            Open();
        }
    }
    
    public void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            allowOpen = true;
        }
    }

    public void OnTriggerExit2D(Collider2D other){
        if(other.CompareTag("Player")){
            allowOpen = false;
        }
    }

    public void Open(){
        playermvoemtn.enabled = false;
        LevelManager.instance.winner();
    }
}
