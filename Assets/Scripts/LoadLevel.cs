using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    public string myFirstScene = "BeginningScene", mySecondScene = "MainGameScene";
    private void OnTriggerEnter2D(Collider2D other)
    {
        Scene scene = SceneManager.GetActiveScene();

        if (scene.name == myFirstScene && other.CompareTag("Player"))
        {
            SceneManager.LoadScene(mySecondScene);
        }
        else if (scene.name == mySecondScene && other.CompareTag("Player"))
        {
            SceneManager.LoadScene(myFirstScene);
        }
    }
}
