using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float dashMult;
    [SerializeField]
    private bool isDashing;
    [SerializeField]
    private float startDashTimer;
    [SerializeField]
    private float currentDashTimer;
    /*
    [SerializeField]
    private float cooldown;
    [SerializeField]
    private float currentCooldown;
    */

    private Vector2 moveDirection;
    
    public Rigidbody2D rb;
 

    void Update()
    {
        if (currentDashTimer > 0)
        {
            currentDashTimer -= Time.deltaTime;
        }

        /*
        if (currentCooldown > 0)
        {
            currentCooldown -= Time.deltaTime;
        }
        */

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

        /*
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (currentCooldown <= 0)
            {
                isDashing = true;
                currentDashTimer = StartDashTimer;
            }    
        }
        */
    }

    void Move()
    {     
       rb.velocity = moveDirection.normalized * moveSpeed;
        
        if (isDashing == true)
        {
            rb.velocity = moveDirection.normalized * moveSpeed * dashMult;

            if (currentDashTimer <= 0)
            {
               isDashing = false;
               //currentCooldown = cooldown;
            }
        }
    }

    public void Dash()
    {
        isDashing = true;
        currentDashTimer = startDashTimer;
    }    
}
