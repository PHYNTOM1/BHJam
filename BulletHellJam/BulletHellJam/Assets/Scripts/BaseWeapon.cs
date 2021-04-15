using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseWeapon : MonoBehaviour
{
    [SerializeField]
    private float shootSpeed;
    [SerializeField]
    private float shootSpeedReal;
    [SerializeField]
    private float minSpread;
    [SerializeField]
    private float maxSpread;

    public GameObject bulletPrefab;
    public Transform gunPoint;


    void Update()
    {
        if (shootSpeedReal > 0)
        {
            shootSpeed -= Time.deltaTime;
        }
    }

    public void Shoot ()
    {
        if (shootSpeedReal <= 0)
        {
            shootSpeedReal = shootSpeed;
        }
    }

}
