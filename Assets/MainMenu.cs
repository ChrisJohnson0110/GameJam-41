using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadSceneAsync());
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }


    IEnumerator LoadSceneAsync()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync("GameScene");

        while (!operation.isDone)
        {
            Debug.Log("Loading progress: " + (operation.progress * 100) + "%");
            yield return null;
        }
    }
}
