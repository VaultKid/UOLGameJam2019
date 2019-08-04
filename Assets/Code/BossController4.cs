using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController4 : MonoBehaviour
{
    public GameObject bossGameObject;
    Rigidbody2D rbBoss;
    private float speed = 50;
    float hitPoints;
    public GameObject target;
    public BulletController bullet;
    private float bulletSpeed = 0.2f;
    private float fireRate = 1;
    private float nextFire = 1;
    public Transform firePoint;

    // Start is called before the first frame update
    void Start()
    {
        hitPoints = 5;
        rbBoss = GetComponent<Rigidbody2D>();
        //InvokeRepeating("JumpBossMovement", time: 1f, 10f);
        //LinearBossMovement();
        //rbBoss.AddForce(new Vector2(0, 10) * speed);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rbBoss.transform.position = Vector2.MoveTowards(rbBoss.transform.position, target.transform.position, 0.02f);
        rbBoss.transform.Rotate(0, 0, -3, Space.Self);
        fire();

        if (hitPoints <= 0) {
            FindObjectOfType<AudioManager>().Play("Explosion1");
            bossGameObject.SetActive(false);
        }
    }

    void LinearBossMovement()
    {
        Vector2 go = new Vector2(0, 10);
        rbBoss.AddForce(go * speed);

        /*
        while(rbBoss.position.y < 10) { 
            collider2d.enabled = false;
            Vector2 jumpup = new Vector2(0, 10);
            rbBoss.AddForce(jumpup * speed);
        }
        Vector2 jumpdown = new Vector2(0, -10);
        rbBoss.AddForce(jumpdown * speed);
        */
    }

    void fire()
    {
        if (Time.time > nextFire) {
            nextFire = Time.time + fireRate;
            Quaternion temp = firePoint.rotation;

            BulletController newBullet = Instantiate(bullet, firePoint.position, temp) as BulletController;
            newBullet.speed = bulletSpeed;

            temp *= Quaternion.Euler(0, 0, 90f);
            BulletController newBullet2 = Instantiate(bullet, firePoint.position, temp) as BulletController;
            newBullet2.speed = bulletSpeed;

            temp *= Quaternion.Euler(0, 0, 90f);
            BulletController newBullet3 = Instantiate(bullet, firePoint.position, temp) as BulletController;
            newBullet3.speed = bulletSpeed;

            temp *= Quaternion.Euler(0, 0, 90f);
            BulletController newBullet4 = Instantiate(bullet, firePoint.position, temp) as BulletController;
            newBullet4.speed = bulletSpeed;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            hitPoints--;
        }
    }
}
