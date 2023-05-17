using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    public string myFirstScene = "BeginningScene", mySecondScene = "MainGameScene", myThirdScene = "PuzzleScene";
    public int coll;
    private void OnTriggerEnter2D(Collider2D other)
    {
        Scene scene = SceneManager.GetActiveScene();

        if (scene.name == myFirstScene && other.CompareTag("Player"))
        {
            SceneManager.LoadScene(mySecondScene);
        }
        else if (scene.name == mySecondScene && other.CompareTag("Player") && coll==2)
        {
            SceneManager.LoadScene(myFirstScene);
        }
        else if (scene.name == myThirdScene && other.CompareTag("Player") )
        {
            SceneManager.LoadScene(mySecondScene);
        }
        else if (scene.name == mySecondScene && other.CompareTag("Player") && coll == 3)
        {
            SceneManager.LoadScene(myThirdScene);
        }
    }
}
