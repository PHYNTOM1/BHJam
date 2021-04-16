using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
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

        if (shootSpeedReal > 0)
        {
            shootSpeedReal -= Time.deltaTime;
        }

        Vector3 _dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        float angle = Mathf.Atan2(_dir.y, _dir.x) * Mathf.Rad2Deg;
        Quaternion _rot = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Lerp(transform.rotation, _rot, rotSpeed * Time.deltaTime);

        if (this.gameObject.transform.rotation.z > 0.7f || this.gameObject.transform.eulerAngles.z < -0.7f)
        {
            if (this.gameObject.transform.localScale.y != -1f)
            {
                this.gameObject.transform.localScale = new Vector3(1f, -1f, 1f);
            }
        }
        else
        {

            if (this.gameObject.transform.localScale.y != 1f)
            {

                this.gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
            }
        }

    }

    public void Shoot()
    {
        if (shootSpeedReal <= 0)
        {
            shootSpeedReal = weapon.shootSpeed;

            for (int i = Random.Range(weapon.minBulletsPerShot, weapon.maxBulletsPerShot + 1); i > 0; i--)
            {
                GameObject _b = Instantiate(weapon.bulletPrefab, weapon.gunPoint.position, this.gameObject.transform.rotation);
            }
        }
    }


    public void UpdateCurrWeapon()
    {
        foreach (Transform child in transform)
        {
            if (child.CompareTag("Weapon"))
            {
                currWeapon = child.gameObject;
                weapon = currWeapon.GetComponent<BaseWeapon>();
                break;
            }
        }
    }    
    
}
