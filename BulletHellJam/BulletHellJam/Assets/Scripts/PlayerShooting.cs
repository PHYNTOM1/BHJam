using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShooting : MonoBehaviour
{
    public Transform gunPoint;
    public SpriteRenderer sr;

    public float rotSpeed = 7f;

    [SerializeField]
    private float shootSpeedReal = 0f;

    public List<BaseWeapon> allWeapons = new List<BaseWeapon>();
    public BaseWeapon currWeapon;

    public BulletPool stonebulletPool;
    public BulletPool magicbulletPool;
    public BulletPool regularbulletPool;

    public List<BaseAmmo> allAmmos = new List<BaseAmmo>();
    public BaseAmmo currAmmo;

    public Text ammoText;
    public Image ammoImage;


    void Start()
    {
        foreach (BaseAmmo ba in allAmmos)
        {
            ba.ammoCurr = ba.ammoMax;
        }
    }

    void Update()
    {
        DoMouseRotation();

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
        if (shootSpeedReal <= 0 && currAmmo.ammoCurr > 0)
        {
            int _bps = Random.Range(currWeapon.minBulletsPerShot, currWeapon.maxBulletsPerShot + 1);
            
            if (_bps > currAmmo.ammoCurr)
            {
                _bps = currAmmo.ammoCurr;
            }
            
            currAmmo.ammoCurr -= _bps;
            shootSpeedReal = currWeapon.shootSpeed;

            ammoText.text = currAmmo.ammoCurr + "/" + currAmmo.ammoMax;


            if (currWeapon.hasPattern)
            {
                float _angleStep = currWeapon.spreadAngle / _bps;
                float _angle = transform.rotation.eulerAngles.z;
                float _offset = (currWeapon.spreadAngle / 2) - (_angleStep / 2);

                for (int i = 0; i < _bps; i++)
                {
                    float _currAngle = _angleStep * i;

                    Quaternion _rot = Quaternion.Euler(new Vector3(0, 0, _angle + _currAngle - _offset));

                    GameObject _b = SpawnBullet();

                    _b.transform.rotation = _rot;
                }
            }
            else
            {
                for (int i = _bps; i > 0; i--)
                {
                    GameObject _b = SpawnBullet();

                    _b.transform.rotation = transform.rotation;
                    _b.transform.Rotate(0, 0, Random.Range(-currWeapon.spreadAngle, currWeapon.spreadAngle));
                }
            }
        }
    }

    private GameObject SpawnBullet()
    {
        GameObject _bt = null;

        switch (currWeapon.bulletType)
        {
            case 0:

                _bt = stonebulletPool.GetBullet();
                break;
            case 1:

                _bt = magicbulletPool.GetBullet();
                break;
            case 2:

                _bt = regularbulletPool.GetBullet();
                break;
            default:

                Debug.LogWarning("ERROR AT POOLING BULLET IN PLAYERSHOOTING!");
                break;
        }

        _bt.transform.position = gunPoint.position;
        _bt.SetActive(true);

        return _bt;
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
                currWeapon = allWeapons[s];
                sr.sprite = currWeapon.sprite;

                foreach (BaseAmmo ba in allAmmos)
                {
                    if (ba.ammoType == currWeapon.bulletType)
                    {
                        currAmmo = ba;
                        ammoImage.sprite = currAmmo.sprite;
                    }
                    break;
                }

                shootSpeedReal = 0f;
                break;
            }           
        }
       
        ReloadCurrAmmo();
    }

    public void ReloadCurrAmmo()
    {
        currAmmo.ammoCurr = currAmmo.ammoMax;
        ammoText.text = currAmmo.ammoCurr + "/" + currAmmo.ammoMax;
    }


}
