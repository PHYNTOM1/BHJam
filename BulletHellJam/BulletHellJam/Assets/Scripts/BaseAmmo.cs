using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New AmmoType", menuName = "AmmoType")]
public class BaseAmmo : ScriptableObject
{
    public int ammoType = 0;
    public Sprite sprite;

    public int ammoCurr = 0;
    public int ammoMax = 0;
}
