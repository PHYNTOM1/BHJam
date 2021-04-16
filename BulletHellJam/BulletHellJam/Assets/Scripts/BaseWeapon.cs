using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseWeapon : MonoBehaviour
{
    public string weaponName = "";
    public float shootSpeed = 1f;
    public int minBulletsPerShot = 1;
    public int maxBulletsPerShot = 1;
    public float minSpread = 0f;
    public float maxSpread = 0f;

    public GameObject bulletPrefab;
    public Transform gunPoint;

}
