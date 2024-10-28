using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerInputHandler : MonoBehaviour
{
    
    [SerializeField] pharmacist player;

    private float horizontal;

    //if player is dashing doesn't allow any other movements
    //how high player jump depends on how long they hold down the space button
    void Update()
    {
        if(player.isDashing){
            return;
        }
        // Get player input for horizontal movement
        horizontal = Input.GetAxisRaw("Horizontal");

        // Handle jump input
        if (Input.GetButtonDown("Jump"))
        {
            player.Jump();
        }

        if (Input.GetButtonUp("Jump"))
        {
            player.ShortenJump();
        }

        if(Input.GetKeyDown(KeyCode.Q)){
           player.launchNeedle();
        }

        if(Input.GetKeyDown(KeyCode.LeftShift) && player.canDash){
            player.Dash();
        }

        // Flip character based on movement direction
        player.Flip(horizontal);
    }

    void FixedUpdate()
    {
        if(player.isDashing){
            return;
        }
        // Move the player character
        player.Move(horizontal);

        
    }
}