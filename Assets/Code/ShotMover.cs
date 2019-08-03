using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotMover : MonoBehaviour
{

    public Rigidbody2D rb;
    public float speed;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //rb.velocity = transform.forward * speed;
        Vector2 vector = new Vector2(0f, 20f);
        rb.AddForce(vector * speed);
    }
}
