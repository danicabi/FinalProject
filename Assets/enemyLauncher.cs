using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyLauncher : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] float projectileSpeed = 15f;
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] Transform spawnTransform; 

    [SerializeField] Enemies enemy;

    void Start(){
        
    }


    //launches a needle and rotates with what direction the player is facing
    public void Launch(){
        
        GameObject newProjectile = Instantiate(projectilePrefab,spawnTransform.position, Quaternion.identity);
        Rigidbody2D rb = newProjectile.GetComponent<Rigidbody2D>();

        if(enemy.isFacingRight){

            rb.velocity = transform.right * projectileSpeed;
           
        }else{
            rb.velocity = -transform.right * projectileSpeed;

            Vector3 localScale = newProjectile.transform.localScale;
            localScale.x *= -1f;
            newProjectile.transform.localScale = localScale;
            
        }
        Destroy(newProjectile,3f);
    }

}
