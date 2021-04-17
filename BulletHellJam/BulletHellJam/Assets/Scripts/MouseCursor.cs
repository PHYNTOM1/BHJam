using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCursor : MonoBehaviour
{
    void Update()
    {
        Vector3 _mPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        this.gameObject.transform.position = new Vector3(_mPos.x, _mPos.y, this.transform.position.z);
    }
}
