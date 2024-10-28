using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boxes : MonoBehaviour, IDamagable
{
    [SerializeField]public float maxHealth = 4f;
    public float currentHealth;
    

    void Start(){
        
        currentHealth = maxHealth;
    }

   
    public void Damage(float damageAmount)
    {
        currentHealth -= damageAmount;

        if(currentHealth <= 0 ){
            Destroy(gameObject);
        }
    }

}
