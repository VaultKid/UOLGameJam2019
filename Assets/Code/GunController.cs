using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{

    //public GameObject bullet;
    //public bool isFiring;

    //public Transform shotSpawn;
    public BulletController bullet;
    public float bulletSpeed;
    public float fireRate;
    private float nextFire;
    public Transform firePoint;

    private void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            BulletController newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation) as BulletController;
            newBullet.speed = bulletSpeed;
            //Instantiate(bullet, shotSpawn.position, shotSpawn.rotation);
            //Rigidbody2D bulletInstance = Instantiate(bullet, transform.position, Quaternion.Euler(new Vector3(0, 0, 1))) as Rigidbody2D;
        }
    }



}

