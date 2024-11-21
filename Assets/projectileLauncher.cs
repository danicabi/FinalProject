using System.Collections;
using System.Collections.Generic;
//using Unity.Mathematics;
using UnityEngine;

public class projectileLauncher : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] float projectileSpeed = 15f;
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] Transform spawnTransform; 

    [SerializeField]pharmacist player;

    void Start(){
        
    }


    //launches a needle and rotates with what direction the player is facing
    public void Launch(){
        GameObject newProjectile = Instantiate(projectilePrefab,spawnTransform.position, Quaternion.identity);
        Rigidbody2D rb = newProjectile.GetComponent<Rigidbody2D>();

        if(player.isFacingRight){

            rb.velocity = transform.right * projectileSpeed;
           
        }else{
            rb.velocity = -transform.right * projectileSpeed;

            Vector3 localScale = newProjectile.transform.localScale;
            localScale.x *= -1f;
            newProjectile.transform.localScale = localScale;
            
        }
        Destroy(newProjectile,3f);
    }

     public void ModifySpeedTemporary(float newSpeed, float duration)
    {
        //StopAllCoroutines(); // Ensure no other speed-changing coroutines are running
        StartCoroutine(TempSpeedChange(newSpeed, duration));
        
        IEnumerator TempSpeedChange(float newSpeed, float duration){
            float originalSpeed = projectileSpeed;
            projectileSpeed = newSpeed;
            //Debug.Log($"Player speed changed to: {player.speed}");

            yield return new WaitForSeconds(duration);

            projectileSpeed = originalSpeed;
            //Debug.Log("Player speed reverted to original: " + player.speed);
    }

    }
}
