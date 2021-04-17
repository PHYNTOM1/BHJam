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

    public List<BaseWeapon> allWeapons = new List<BaseWeapon>();

    public BulletPool stonebulletPool;
    public BulletPool magicbulletPool;


    void Update()
    {
        DoMouseRotation();

        WeaponSwitching();


        if (Input.GetButton("Fire1"))
        {
            Shoot();
        }

        if (shootSpeedReal > 0)
        {
            shootSpeedReal -= Time.deltaTime;
        }

    }

    public void Shoot()
    {
        if (shootSpeedReal <= 0)
        {
            shootSpeedReal = weapon.shootSpeed;

            if (weapon.hasPattern)
            {
                int _bps = Random.Range(weapon.minBulletsPerShot, weapon.maxBulletsPerShot + 1);

                float _angleStep = weapon.spreadAngle / _bps;
                float _angle = transform.rotation.eulerAngles.z;
                float _offset = (weapon.spreadAngle / 2) - (_angleStep / 2);

                for (int i = 0; i < _bps; i++)
                {
                    float _currAngle = _angleStep * i;

                    Quaternion _rot = Quaternion.Euler(new Vector3(0, 0, _angle + _currAngle - _offset));

                    GameObject _b = null;

                    switch (weapon.bulletType)
                    {
                        case 0:

                            _b = stonebulletPool.GetBullet();
                            break;
                        case 1:

                            _b = magicbulletPool.GetBullet();
                            break;

                        default:

                            Debug.LogWarning("ERROR AT POOLING BULLET IN PLAYERSHOOTING!");
                            break;
                    }
                    
                    _b.transform.position = gunPoint.position;
                    _b.transform.rotation = _rot;
                    _b.SetActive(true);

                    //GameObject _b = Instantiate(weapon.bulletPrefab, gunPoint.position, _rot);
                }
            }
            else
            {
                for (int i = Random.Range(weapon.minBulletsPerShot, weapon.maxBulletsPerShot + 1); i > 0; i--)
                {
                    GameObject _b = null;

                    switch (weapon.bulletType)
                    {
                        case 0:

                            _b = stonebulletPool.GetBullet();
                            break;
                        case 1:

                            _b = magicbulletPool.GetBullet();
                            break;

                        default:

                            Debug.LogWarning("ERROR AT POOLING BULLET IN PLAYERSHOOTING!");
                            break;
                    }

                    _b.transform.position = gunPoint.position;
                    _b.transform.rotation = this.gameObject.transform.rotation;
                    _b.SetActive(true);

                    //GameObject _b = Instantiate(weapon.bulletPrefab, gunPoint.position, this.gameObject.transform.rotation);

                    _b.transform.Rotate(0, 0, Random.Range(-weapon.spreadAngle, weapon.spreadAngle));
                }
            }
        }
    }


    private void WeaponSwitching()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SetWeapon(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SetWeapon(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SetWeapon(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SetWeapon(3);
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


    public void SetWeapon(int s)
    {
        foreach (BaseWeapon bw in allWeapons)
        {
            if (s == bw.weaponID)
            {
                weapon = allWeapons[s];
                sr.sprite = weapon.sprite;

                shootSpeedReal = 0f;
            }
        }
    }


}
