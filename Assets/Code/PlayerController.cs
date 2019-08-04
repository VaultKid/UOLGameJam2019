using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

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

    public GameObject playerObject;
    Rigidbody2D body;
    public float power = 5;
    public float maxspeed = 20;
    public float turnpower = 3;
    public float friction = 100;
    public Vector2 curspeed;
    public int hitPoints;
    private Progress progress;
    private SpriteRenderer spriteRenderer;

    void Start() {
        body = GetComponent<Rigidbody2D>();
        progress = FindObjectOfType<Progress>();
        handlePowerUps();
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

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Enemy")) {
            hitPoints--;
            Debug.Log(hitPoints);
            if (hitPoints <= 0) {
                FindObjectOfType<AudioManager>().Play("Explosion2");
                playerObject.SetActive(false);
            }
        }
    }

    private void handlePowerUps() {
        if (progress.invisibility) {
            GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
