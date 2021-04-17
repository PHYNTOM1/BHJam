using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public GameObject pooledBullet;
    
    private bool notEnoughBinP = true;

    private List<GameObject> bullets = new List<GameObject>();


    public GameObject GetBullet()
    {
        if (bullets.Count > 0)
        {
            for (int i = 0; i < bullets.Count; i++)
            {
                if (!bullets[i].activeInHierarchy)
                {
                    return bullets[i];
                }
            }
        }

        if (notEnoughBinP)
        {
            GameObject _b = Instantiate(pooledBullet);
            _b.SetActive(false);
            bullets.Add(_b);
            return _b;
        }

        return null;
    }
}
