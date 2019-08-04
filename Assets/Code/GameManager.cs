using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject boss;
    public GameObject overlay;
    public GameObject GameOverCanvas;
    private bool won;
    private bool lose;
    private bool allowContinue;
    private bool allowGameOver;
    public int bossNumber;
    public Text powerUpText;
    private PlayerController playerController;

    private void Start() {
        won = false;
        lose = false;
        allowContinue = false;
        playerController = FindObjectOfType<PlayerController>();
    }

    void Update()
    {
        if (boss.activeInHierarchy == false && !won) {
            won = true;
            Victory();
        }

        if (playerController.gameOver && !lose) {
            lose = true;
            GameOver();
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
            if (bossNumber == 4) {
                FindObjectOfType<Progress>().superSpeed = true;
            }
            SceneManager.LoadScene(1);
        }

        if (Input.GetButton("Fire1") && allowGameOver) {
            FindObjectOfType<Progress>().Reset();
            SceneManager.LoadScene(0);
        }
    }

    private void Victory() {
        StartCoroutine(WaitForVictory());
    }

    IEnumerator WaitForVictory() {
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
        if (bossNumber == 4) {
            powerUpText.text = "SUPER SPEED gained!";
        }

        allowContinue = true;
    }

    private void GameOver() {
        StartCoroutine(WaitForGameOver());
    }

    IEnumerator WaitForGameOver() {
        yield return new WaitForSeconds(2.0f);
        GameOverCanvas.SetActive(true);
        allowGameOver = true;
    }


}
