using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public Transform gunPoint;
    public SpriteRenderer sr;
    public BaseWeapon weapon;

    public float rotSpeed = 7f;

    [SerializeField]
    private float shootSpeedReal = 0f;

    

    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            Shoot();
        }

        if (shootSpeedReal > 0)
        {
            shootSpeedReal -= Time.deltaTime;
        }

        DoMouseRotation();

    }

    public void Shoot()
    {
        if (shootSpeedReal <= 0)
        {
            shootSpeedReal = weapon.shootSpeed;

            for (int i = Random.Range(weapon.minBulletsPerShot, weapon.maxBulletsPerShot + 1); i > 0; i--)
            {
                GameObject _b = Instantiate(weapon.bulletPrefab, gunPoint.position, this.gameObject.transform.rotation);
            }
        }
    }


    private void DoMouseRotation()
    {
        Vector3 _dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        float angle = Mathf.Atan2(_dir.y, _dir.x) * Mathf.Rad2Deg;
        Quaternion _rot = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Lerp(transform.rotation, _rot, rotSpeed * Time.deltaTime);

        if (this.transform.rotation.z <= -0.7f || this.transform.rotation.z >= 0.7f)
        {
            sr.flipY = true;
        }
        else
        {
            sr.flipY = false;
        }
    }

}
