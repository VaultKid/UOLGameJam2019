using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    private Rigidbody2D rb;
    public float speed;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //rb.velocity = transform.forward * speed;
        //Vector2 vector = new Vector2(0f, 20f);
        //rb.AddForce(vector * speed);
        //transform.Translate(Vector3.forward*speed);
    }

    private void FixedUpdate() {
        transform.Translate(Vector3.up* speed);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Debug.Log("collision happened");
            Destroy(this);

        }
    }
}
