using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject currWeapon;
    [SerializeField]
    private BaseWeapon weapon;

    public float rotSpeed = 7f;

    [SerializeField]
    private float shootSpeedReal = 0f;


    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            Shoot();
        }    

    }

    public void Shoot()
    {
        if (shootSpeedReal <= 0)
        {
            shootSpeedReal = weapon.shootSpeed;

            GameObject _b = Instantiate(weapon.bulletPrefab, weapon.gunPoint);
            _b.transform.parent = null;
        }
    }
    
}
