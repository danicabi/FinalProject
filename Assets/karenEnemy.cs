using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.Timeline;

public class karenEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Enemies enemy;
    [SerializeField] pharmacist targetPlayer;
    delegate void AIState();
    AIState currentState;

    [Header("Config")]
    [SerializeField] float sightDistance = 5;
    float direction = 1;


    void Start()
    {
        if(targetPlayer == null){
            return;
        }
       changeState(patrolState);


    }

    void changeState(AIState newAIState){
        currentState = newAIState;
    }
    void Idle(){
        //Debug.Log("IDLE");
        if(Vector3.Distance(enemy.transform.position, targetPlayer.transform.position) < sightDistance){
            changeState(followState);
            return;
        }
    }
    void followState(){
        //Debug.Log("Following");
        enemy.moveTowards(targetPlayer.transform.position);
        //tracks player
        if(targetPlayer.transform.position.x < enemy.transform.position.x){
            if(enemy.isFacingRight){
                enemy.Flip();
            }
        }else{
            if(!enemy.isFacingRight){
                enemy.Flip();
            }
        }
        
        /*if(Vector3.Distance(enemy.transform.position, targetPlayer.transform.position) < sightDistance){
            changeState(followState);
            
        }*/

        if(Vector3.Distance(enemy.transform.position, targetPlayer.transform.position) > sightDistance){
            changeState(patrolState);
            
        }
    }

    void patrolState(){
        //do something here
        enemy.Move(direction);
        //Debug.Log("patroling");
        if(enemy.IsAgainstWall()){
            enemy.Flip();
            direction *= -1;
        }

        

        /*if(Vector3.Distance(enemy.transform.position, targetPlayer.transform.position) > sightDistance){
            changeState(patrolState);
            
        }*/

        if(Vector3.Distance(enemy.transform.position, targetPlayer.transform.position) < sightDistance){
            changeState(followState);
            return;
        }
    }
    // Update is called once per frame
    void Update()
    {
        AITick();
    }
    public void AITick(){
        if(targetPlayer == null){
            return;
        }
        currentState();
    }

    
    
}
