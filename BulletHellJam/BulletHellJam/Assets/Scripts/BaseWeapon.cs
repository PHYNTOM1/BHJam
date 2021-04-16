using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon")]
public class BaseWeapon : ScriptableObject
{
    public int weaponID = 0;
    public float shootSpeed = 1f;
    public int minBulletsPerShot = 1;
    public int maxBulletsPerShot = 1;
    public bool hasPattern = false;
    public float spreadAngle = 0f;

    public Sprite sprite;
    public GameObject bulletPrefab;

}
