using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.AI;

public class pharmacist : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Basic")]
    public float currentHealth;
    public float maxHealth = 5;
    public float speed = 8f;
    public float dashDamage = 10f;
    public float dashingPower = 24f;
    public float jumpingPower = 16f;
    public bool isFacingRight = true;

    [Header("Tools")]
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundLayer;
    
    
    [SerializeField] projectileLauncher projectilelauncher;
    [SerializeField] TrailRenderer tr;
    
    [Header("Destroy")]
    public SpriteRenderer playerSR;
    public playerInputHandler playermvoemtn;
    public SpriteRenderer gun;
    public cameraFollow cam;

    [Header("Dashing Extras")]
    public bool canDash = true;
    public bool isDashing;
    
    public float dashingTime = 0.2f;
    public float dashingCD = 1f;

    


    void Start(){
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
    }
    void FixedUpdate()
    {
        // Movement will now be handled by the playerInputHandler
    }

    public bool IsGrounded(){
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    public void Flip(float horizontal)
    {
        if(isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    public void Jump()
    {
        if (IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }
    }

    public void ShortenJump()
    {
        if (rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
    }

    public void Move(float horizontal)
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    

    public void launchNeedle(){
        projectilelauncher.Launch();
    }

    public void Dash(){
        StartCoroutine(DashCoroutine());
         IEnumerator DashCoroutine(){
            canDash = false;
            isDashing = true;
            float orginalGravity = rb.gravityScale;
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
            tr.emitting = true;

            ToggleBoxTriggers(true);

            yield return new WaitForSeconds(dashingTime);
            tr.emitting = false;
            rb.gravityScale = orginalGravity;
            isDashing = false;

            ToggleBoxTriggers(false);

            yield return new WaitForSeconds(dashingCD);
            canDash = true;
        }
    }


    void ToggleBoxTriggers(bool state){
    // Find all boxes in the scene and toggle their triggers
        GameObject[] boxes = GameObject.FindGameObjectsWithTag("boxes");
        foreach (GameObject box in boxes)
        {
            Collider2D boxCollider = box.GetComponent<Collider2D>();
            if (boxCollider != null)
            {
                boxCollider.isTrigger = state;
            }
        }
    }

     public void OnTriggerEnter2D(Collider2D other){
        if((other.CompareTag("boxes") || other.CompareTag("Enemy")) && isDashing){
            IDamagable idamagable = other.gameObject.GetComponent<IDamagable>();
            if(idamagable != null){
                 //play sound
                idamagable.Damage(dashDamage);
            }
        }

        if(other.CompareTag("Enemy") && !isDashing || other.CompareTag("pill")){
            TakeDamage();
            //play sound
        }

        if(other.CompareTag("instant death") ){
            Debug.Log("falling");
            currentHealth = currentHealth - 5;
            TakeDamage();
            //play sound
        }
        
    }

    public float playersHealth(){
        return currentHealth;
    }

    public void setPlayerHealth(){
        
    }

    public void TakeDamage(){

        currentHealth -= 1;
        //kill player
        //Debug.Log("Player's current health: " + currentHealth);
        if(currentHealth <= 0){
                playerSR.enabled = false;
                playermvoemtn.enabled = false;
                //projectilelauncher.enabled = false;
                //gun.enabled = false;
                //cam.enabled = false;
            
                //DestroyPlayer();
                //Destroy(gameObject);
                //next scene??
                //might just remove all this and take to deathscreen?
                //Destroy(this.gameObject);
                PlayerDied();
            }
        
    }

    public void PlayerDied(){
        LevelManager.instance.GameOver();
        //gameObject.SetActive(false);
        Destroy(this.gameObject);
    }


    
}
