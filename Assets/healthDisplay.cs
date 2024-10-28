using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class healthDisplay : MonoBehaviour
{
    public float health;
    public float maxHealth;

    public Sprite emptyheart;
    public Sprite[] fullheart;
    public Image[] hearts;

    [SerializeField] pharmacist player;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if(player == null){
            //Debug.Log("Player is null, displaying empty hearts.");
            for(int i = 0; i < hearts.Length; i++){
                hearts[i].sprite = emptyheart;
            }
            return;
        }
        
        ///Debug.Log("Updating health display...");
        //Debug.Log("Player's current health: " + health);
        maxHealth = player.maxHealth;
        health = player.currentHealth;
        for(int i = 0; i < hearts.Length; i++){

            if(i < health){
                hearts[i].sprite = fullheart[i];
            }else{
                hearts[i].sprite = emptyheart;
            }


            if(i < maxHealth){
                hearts[i].enabled = true;
            }else{
                hearts[i].enabled = false;
            }
        }
    }
}
