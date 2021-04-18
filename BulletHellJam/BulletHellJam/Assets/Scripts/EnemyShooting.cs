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

    [SerializeField]
    private float shootSpeed = 1f;
    [SerializeField]
    private float shootSpeedReal = 1f;

    public enum PatternType
    {
        horizontal,
        vertical,
        quaddirectional,
        xdirectional,
        quadrotating,
        quadsinus,
        swirl
    };

    public PatternType patternType;

    public BulletPool bulletPool;


    void Start()
    {
        
    }

    void Update()
    {
        if (shootSpeedReal > 0)
        {
            shootSpeedReal -= Time.deltaTime;
        }
        else
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        shootSpeedReal = shootSpeed;

        switch (patternType)
        {
            case PatternType.horizontal:

                ShootHorizontal();
                break;
            case PatternType.vertical:

                ShootVertical();
                break;
            case PatternType.quaddirectional:

                ShootQuaddirectional();
                break;
            case PatternType.xdirectional:

                ShootXdirectional();
                break;
            case PatternType.quadrotating:

                ShootQuadrotating();
                break;
            case PatternType.quadsinus:

                ShootQuadsinus();
                break;
            case PatternType.swirl:

                ShootSwirl();
                break;
            default:

                Debug.LogWarning("ERROR AT PATTERNTYPE IN ENEMYSHOOT!");
                break;
        }
    }


    private void ShootHorizontal()
    {

    }

    private void ShootVertical()
    {

    }

    private void ShootQuaddirectional()
    {

    }

    private void ShootXdirectional()
    {

    }

    private void ShootQuadrotating()
    {

    }

    private void ShootQuadsinus()
    {
        float _bulletAmount = 50;
        float _angleStep = 360 / _bulletAmount;
        float _angle = transform.rotation.eulerAngles.z;
        float _offset = (360 / 2) - (_angleStep / 2);

        for (int i = 0; i < _bulletAmount; i++)
        {
            float _currAngle = _angleStep * i;

            Quaternion _rot = Quaternion.Euler(new Vector3(0, 0, _angle + _currAngle - _offset));

            GameObject _b = bulletPool.GetBullet();

            _b.transform.rotation = _rot;
            _b.transform.position = gameObject.transform.position;
            _b.SetActive(true);
        }
    }

    private void ShootSwirl()
    {
        float _bulletAmount = 50;
        float _angleStep = 360 / _bulletAmount;
        float _angle = transform.rotation.eulerAngles.z;
        float _offset = (360 / 2) - (_angleStep / 2);

        for (int i = 0; i < _bulletAmount; i++)
        {
            float _currAngle = _angleStep * i;

            Quaternion _rot = Quaternion.Euler(new Vector3(0, 0, _angle + _currAngle - _offset));

            GameObject _b = bulletPool.GetBullet();

            _b.transform.rotation = _rot;
            _b.transform.Rotate(0, 0, 20);
            _b.transform.position = gameObject.transform.position;
            _b.SetActive(true);
        }
    }

}
