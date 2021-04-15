using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public abstract class BaseBullet : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float deathTime = 1f;

    public GameObject hitEffect;
    public Rigidbody2D rb;

    void Start()
    {
        Destroy(this.gameObject, deathTime);
    }

    void FixedUpdate()
    {
        rb.velocity = transform.TransformDirection(this.gameObject.transform.forward).normalized * moveSpeed * 10f * Time.fixedDeltaTime;
    }
}
