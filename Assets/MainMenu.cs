using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button switchSceneButton;
    private AsyncOperation asyncLoad;
    void Start()
    {
        switchSceneButton.interactable = false;
        StartCoroutine(LoadSceneInBackground());
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    IEnumerator LoadSceneInBackground()
    {
        asyncLoad = SceneManager.LoadSceneAsync("GameScene");
        asyncLoad.allowSceneActivation = false;

        while (asyncLoad.progress < 0.9f)
        {
            yield return null;
        }
        switchSceneButton.interactable = true;
    }
}
