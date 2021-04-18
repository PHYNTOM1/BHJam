using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBullet : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float deathTime = 1f;

    public GameObject hitEffect;
    public Rigidbody2D rb;


    void OnEnable()
    {
        Invoke("DoDestroy", deathTime);
    }

    void FixedUpdate()
    {
        rb.velocity = this.gameObject.transform.right * moveSpeed * 100f * Time.fixedDeltaTime;
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (this.gameObject.CompareTag("PlayerBullet"))
        {
            if (!coll.gameObject.CompareTag("Player") && !coll.gameObject.CompareTag("PlayerBullet"))
            {
                if (coll.gameObject.CompareTag("Enemy"))
                {
                    //do dmg here
                }

                //Instantiate(hitEffect, coll.GetContact(0), Quaternion.identity);
                DoDestroy();
            }
        }
        else if (this.gameObject.CompareTag("EnemyBullet"))
        {
            if (!coll.gameObject.CompareTag("Enemy") && !coll.gameObject.CompareTag("EnemyBullet"))
            {
                if (coll.gameObject.CompareTag("Player"))
                {
                    //do dmg here
                }

                //Instantiate(hitEffect, coll.GetContact(0), Quaternion.identity);
                DoDestroy();
            }
        }
    }

    private void DoDestroy()
    {
        this.gameObject.SetActive(false);
    }

}
