using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class needleBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public float needleDamage = 2f;


    //Destroys needle to any of these tags and damages them if they can be damaged
    public void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("boxes") || other.CompareTag("Enemy") || other.CompareTag("wall")){
            //spawn particle

            //play sound

            //damage enumy
            IDamagable idamagable = other.gameObject.GetComponent<IDamagable>();
            if(idamagable != null){
                idamagable.Damage(needleDamage);
            }
            //destroy bullet
            Destroy(this.gameObject);
        }
    }
}
