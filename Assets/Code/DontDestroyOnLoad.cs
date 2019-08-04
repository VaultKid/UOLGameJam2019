using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    private static DontDestroyOnLoad ddol;
    void Awake() {
        DontDestroyOnLoad(transform.gameObject);
        if(ddol == null) {
            ddol = this;
        }
        else {
            Destroy(gameObject);
        }
    }
}
