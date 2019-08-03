using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, yMin, yMax;
}

public class Schussfaehigkeit : MonoBehaviour
{
    public float speed;
    public float tilt;
    public Boundary boundary;

    private void Update()
    {
        Instantiate (object, position, rotation);
    }



}

