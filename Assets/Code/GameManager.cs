using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject boss;
    public GameObject overlay;
    private bool won;
    private bool allowContinue;

    public bool invisibility;

    private void Start() {
        won = false;
        allowContinue = false;
    }

    void Update()
    {
        if (boss.activeInHierarchy == false && !won) {
            won = true;
            Victory();
        }
        if (Input.GetButton("Fire1") && allowContinue) {
            SceneManager.LoadScene(1);
        }
    }

    private void Victory() {
        StartCoroutine(wait());
    }

    IEnumerator wait() {
        yield return new WaitForSeconds(2.0f);
        overlay.SetActive(true);
        allowContinue = true;
    }
}
