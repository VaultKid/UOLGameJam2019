using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject boss;
    public GameObject overlay;
    private bool won;
    private bool allowContinue;
    public int bossNumber;
    public Text powerUpText;

    //private bool invisibility;

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
            if(bossNumber == 1) {
                FindObjectOfType<Progress>().invisibility = true;
            }
            if (bossNumber == 2) {
                FindObjectOfType<Progress>().slowBullets = true;
            }
            if (bossNumber == 3) {
                FindObjectOfType<Progress>().slowFireRate = true;
            }
            SceneManager.LoadScene(1);
        }
    }

    private void Victory() {
        StartCoroutine(wait());
    }

    IEnumerator wait() {
        yield return new WaitForSeconds(2.0f);
        overlay.SetActive(true);
        if (bossNumber == 1) {
            powerUpText.text = "Invisibility gained!";
        }
        if (bossNumber == 2) {
            powerUpText.text = "More DMG but slower bullets gained!";
        }
        if (bossNumber == 3) {
            powerUpText.text = "More DMG but slower firerate gained!";
        }

        allowContinue = true;
    }
}
