using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss3Control : MonoBehaviour
{
    public Transform Player;
    public GameObject bossGameObject;
    Rigidbody2D rbBoss3;
    public float movementSpeed = 5;
    public float hitPoints;
    public float MaxDist = 100000;
    public float MinDist = 0;

    void Start()
    {
        hitPoints = 10;
        rbBoss3 = GetComponent<Rigidbody2D>();
    }

     void Update()
    {
        transform.LookAt(Player);
        transform.position += transform.forward * movementSpeed * Time.deltaTime;
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
