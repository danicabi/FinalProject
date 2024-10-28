using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pillBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public float pillDamage = 1f;


    //Destroys needle to any of these tags and damages them if they can be damaged
    public void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("boxes") || other.CompareTag("Player") || other.CompareTag("wall")){
            //spawn particle

            //play sound

            //damage enumy
            IDamagable idamagable = other.gameObject.GetComponent<IDamagable>();
            if(idamagable != null){
                idamagable.Damage(pillDamage);
            }
            //destroy bullet
            Destroy(this.gameObject);
        }
    }
}
