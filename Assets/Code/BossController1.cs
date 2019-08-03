using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossController1 : MonoBehaviour
{
    public GameObject bossGameObject;
    Rigidbody2D rbBoss;
    public float speed;
    float hitPoints;

    void Start()
    {
        hitPoints = 5;
        rbBoss = GetComponent<Rigidbody2D>();
        InvokeRepeating("randomBossMovement", 1f, 1.0f);

    }

    public void randomBossMovement() {
        Vector2 randomMovement = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        rbBoss.AddForce(randomMovement*speed);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Bullet")) {
            hitPoints--;
            Debug.Log(hitPoints);
            if(hitPoints == 0) {
                bossGameObject.SetActive(false);
            }
        }
    }
}
