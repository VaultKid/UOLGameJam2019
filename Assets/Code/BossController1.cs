using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossController1 : MonoBehaviour
{
    public GameObject bossGameObject;
    Rigidbody2D rbBoss;
    public float speed;
    public float hitPoints;
    public Animator animator;
    public GameObject bossObject;

    void Start()
    {
        hitPoints = 20;
        rbBoss = GetComponent<Rigidbody2D>();
        InvokeRepeating("randomBossMovement", 1f, 1.0f);
    }

    void Update() {
        if (hitPoints <= 0) {
            //FindObjectOfType<AudioManager>().Play("Explosion1");
            bossObject.SetActive(false);
            animator.SetBool("isAlive", false);
        }
    }

    public void randomBossMovement() {
        Vector2 randomMovement = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        rbBoss.AddForce(randomMovement*speed);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Bullet")) {
            hitPoints--;
        }
    }
}
