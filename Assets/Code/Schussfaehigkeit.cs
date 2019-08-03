using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, yMin, yMax;
}

public class Schussfaehigkeit : MonoBehaviour
{
    public float speed;
    public float tilt;
    public Boundary boundary;

    public GameObject bullet;
    public Transform shotSpawn;
    public float fireRate;

    private float nextFire;

    private void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(bullet, shotSpawn.position, shotSpawn.rotation);
        }
    }



}

