using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiFollower : MonoBehaviour
{
    [SerializeField]
    private GameObject target; 

    void Update()
    {
        this.transform.position = Camera.main.WorldToScreenPoint(target.transform.position);
    }
}
