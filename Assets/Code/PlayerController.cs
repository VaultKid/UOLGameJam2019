using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D body;
    /*
    float horizontal;
    float vertical;
    public float moveLimiter;
    public float runSpeed;
    public float rotationSpeed;
    private Transform playerTransform;
    public float rotationValue;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        playerTransform = GetComponent<Transform>();
        rotationValue = 0f;
    }

    void Update()
    {
        // Gives a value between -1 and 1
        horizontal = Input.GetAxisRaw("Horizontal"); // -1 is left
        vertical = Input.GetAxisRaw("Vertical"); // -1 is down
    }

    void FixedUpdate()
    {
        if (horizontal != 0 && vertical != 0) // Check for diagonal movement
        {
            // limit movement speed diagonally, so you move at 70% speed
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        }
       
        playerTransform.Rotate (0,0,-horizontal*rotationSpeed);
        Vector2 vector = new Vector2(horizontal, vertical);
        //body.MoveRotation(-horizontal);
        body.AddForce(vector*runSpeed);
    }
    */

    public float power = 30;
    public float maxspeed = 50;
    public float turnpower = 3;
    public float friction = 1;
    public Vector2 curspeed;

    void Start() {
        body = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() {
        curspeed = new Vector2(body.velocity.x, body.velocity.y);

        if (curspeed.magnitude > maxspeed) {
            curspeed = curspeed.normalized;
            curspeed *= maxspeed;
        }

        if (Input.GetKey(KeyCode.W)) {
            body.AddForce(transform.up * power);
            body.drag = friction;
        }
        if (Input.GetKey(KeyCode.S)) {
            body.AddForce(-(transform.up) * (power / 2));
            body.drag = friction;
        }
        if (Input.GetKey(KeyCode.A)) {
            transform.Rotate(Vector3.forward * turnpower);
        }
        if (Input.GetKey(KeyCode.D)) {
            transform.Rotate(Vector3.forward * -turnpower);
        }

        noGas();
    }

    void noGas() {
        bool gas;
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S)) {
            gas = true;
        }
        else {
            gas = false;
        }
        if (!gas) {
            body.drag = friction * 2;
        }
    }
}
