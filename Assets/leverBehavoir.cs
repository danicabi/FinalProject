using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leverBehavoir : MonoBehaviour
{
    bool isOn = false;
    [SerializeField]movingPlatform mp;

    public void Update(){
        if(isOn && Input.GetKeyDown(KeyCode.E)){
            Onplatform();
        }
    }

    public void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            isOn = true;
        }
    }

    public void Onplatform(){
        mp.start = true;
    }
   
}
