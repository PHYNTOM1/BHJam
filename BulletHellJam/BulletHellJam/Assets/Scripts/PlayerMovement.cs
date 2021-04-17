using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject player;
    public float moveSpeed;
    public Rigidbody2D rb;
    private Vector2 moveDirection;
    public float dashSpeed;
    private bool isDashing;
    public float StartDashTimer;
    private float currentDashTimer;
    public float cooldown;
    private float currentCooldown;
    

    public ParticleSystem ParticleOnDash;
 

    void Update()
    {
        ProcessInputs(); 
    }

    void FixedUpdate()
    {
        Move();
    }

    void ProcessInputs()
    {

        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY);

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (currentCooldown <= 0)
            {
                isDashing = true;
                ParticleOnDash.Play();
            }    
            
        }
    }

    void Move()
    {
       currentDashTimer -= Time.deltaTime;
       currentCooldown -= Time.deltaTime;
        
       rb.velocity = moveDirection.normalized * moveSpeed;
        
        if (isDashing == true)
        {
            rb.velocity = moveDirection.normalized * moveSpeed * dashSpeed;
        }
        if (currentDashTimer <= 0)
        {
           isDashing = false;
           currentDashTimer = StartDashTimer;
           currentCooldown = cooldown;
        }
        

        
        
    }
}
