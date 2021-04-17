using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    //Random.insideUnitSphere - random start dir
    // ---
    //function Fire(){
    //var rotation : Quaternion = Quaternion.identity;
    //rotation.eulerAngles = Random.insideUnitSphere;
    //var bullet : GameObject;
    //bullet = Instantiate(BulletPrefab, transform.position, rotation);
    //bullet.rigidbody.velocity = bullet.transform.forward* bulletSpeed;
    //}
    //yRotation : float = 0;
    //
    //function IncrementAngle()
    //{
    //    yRotation += 5;
    //    if (yRotation > 359)
    //    {
    //        yRotation = -359;
    //    }
    //}
    // ---
    //Have an empty (A), with several empties (B) attached. 
    //Each (B) is facing away from (A). Then by rotating (A), 
    //and launching projectiles from each (B) along whichever axis is facing away from (A).

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
