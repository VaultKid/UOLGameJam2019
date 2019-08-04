using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Progress : MonoBehaviour
{
    public bool invisibility;
    public bool slowBullets;
    public bool slowFireRate;
    public bool superSpeed;

    private void Start() {
        invisibility = false;
        slowBullets = false;
        slowFireRate = false;
        superSpeed = false;
    }

    public void Reset() {
        invisibility = false;
        slowBullets = false;
        slowFireRate = false;
        superSpeed = false;
    }
}
