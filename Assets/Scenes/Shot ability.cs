using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotCreation : MonoBehaviour
{
    public float speed;
    public Rigidbody2D shot;

    void Start()
    {
        shot.velocity = transform.forward * speed;
    }

}
