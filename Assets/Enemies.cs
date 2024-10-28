using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Enemies : MonoBehaviour,IDamagable
{
    [SerializeField]public float maxHealth = 10f;
    public float currentHealth;
    [SerializeField] enemyLauncher projectilelauncher;

     [SerializeField] Rigidbody2D rb;
     [SerializeField] private Transform wallCheck;
    [SerializeField] private LayerMask wallLayer;
     public float speed = 2f;
     public bool isFacingRight = true;
     
    
    

    void Start(){
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        
    }

    void Update(){

       
        //if(IsAgainstWall()){
            //Debug.Log("TouchingWall");
            //Flip();
        //}
    }

    public void Damage(float damageAmount)
    {
        currentHealth -= damageAmount;

        if(currentHealth <= 0 ){
            Destroy(gameObject);
        }
    }

    //launch projectile
    public void launchPill(){
            projectilelauncher.Launch();
        
    }

    public void Move(float direction)
    {
        //Vector3 movement = Vector3.forward;
        //movement += new Vector3(1,0,0) * direction;
        //rb.velocity = movement * speed;
        rb.velocity = new Vector2(direction * speed, rb.velocity.y);
    }

    public void moveTowards(Vector3 goalPos){
        goalPos.z = 0;
        Vector3 direction = goalPos - transform.position;
        Move(direction.x);
    }

    public bool IsAgainstWall(){
        
        return Physics2D.OverlapCircle(wallCheck.position, 0.2f, wallLayer);
        
    }

    public void Flip(){
        isFacingRight = !isFacingRight;

        // Flip the enemy's direction by inverting its local scale
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
}

    
    

