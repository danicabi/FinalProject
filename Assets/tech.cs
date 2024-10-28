using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tech : MonoBehaviour
{
     [SerializeField] Enemies enemy;
    [SerializeField] pharmacist targetPlayer;
    delegate void AIState();
    AIState currentState;

    [Header("Config")]
    [SerializeField] float sightDistance = 5;

    //public bool isAttacking = false;
    public float timer = 2;
    public float coolDownTime = 2;
    


    void Start()
    {
       changeState(Idle);


    }

    void changeState(AIState newAIState){
        if(targetPlayer == null){
            return;
        }
        currentState = newAIState;
    }

    void Idle(){
        //Debug.Log("IDLE");
        timer = 0;
        if( Vector3.Distance(enemy.transform.position, targetPlayer.transform.position) < sightDistance){
            changeState(attackState);
            return;
        }
    }

    void attackState(){
        //Debug.Log(isAttacking);
        //if(!isAttacking){
            //Debug.Log("is not attacking");
            //isAttacking = true;
            
            
        //}

        //Debug.Log("attack");
        

            if(targetPlayer.transform.position.x < enemy.transform.position.x){

                if(enemy.isFacingRight){
                    enemy.Flip();
                }
            }else{
                if(!enemy.isFacingRight){
                    enemy.Flip();
                }
            }
        

         

       if(timer > coolDownTime){
                timer = 0;
                enemy.launchPill();
        }
        timer += Time.deltaTime;

       
       

        

        if(Vector3.Distance(enemy.transform.position, targetPlayer.transform.position) > sightDistance){
            //isAttacking = false;
            changeState(Idle);
            return;
        }
    }

    
      
        
    

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
