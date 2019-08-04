using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    public string scene;
    public void NextScene()
    {
        FindObjectOfType<AudioManager>().Play("Ui");
        SceneManager.LoadScene(scene);
    }
}
