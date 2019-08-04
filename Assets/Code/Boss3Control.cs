using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Boss3Control : MonoBehaviour
{
    public GameObject bossGameObject;
    Rigidbody2D rbBoss;
    public float speed;
    float hitPoints;
    public GameObject target;
    public float fireRate;
    public float nextFire;
    public Transform firePoint;
    public BulletController bullet;
    public float bulletSpeed;

    void Start()
    {
        hitPoints = 5;
        rbBoss = GetComponent<Rigidbody2D>();
      
    }

    private void Update()
    {
        Vector2 direction = target.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);
        transform.position += transform.right * speed * Time.deltaTime;

        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Quaternion temp = firePoint.rotation;
            temp *= Quaternion.Euler(0, 0, -90f);
            BulletController newBullet = Instantiate(bullet, firePoint.position, temp) as BulletController;
            newBullet.speed = bulletSpeed;
        }
    }
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            hitPoints--;
            Debug.Log(hitPoints);
            if (hitPoints == 0)
            {
                bossGameObject.SetActive(false);
            }
        }
    }
}
