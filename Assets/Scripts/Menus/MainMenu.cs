using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button switchSceneButton;
    [SerializeField] private TMP_Text loadingText;
    private AsyncOperation asyncLoad;
    void Start()
    {
        switchSceneButton.gameObject.SetActive(false);
        StartCoroutine(LoadSceneInBackground());
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void Multiplayer()
    {
        SceneManager.LoadScene("MultiplayerSetup");
    }

    IEnumerator LoadSceneInBackground()
    {
        asyncLoad = SceneManager.LoadSceneAsync("GameScene");
        asyncLoad.allowSceneActivation = false;

        loadingText.text = asyncLoad.progress.ToString();

        while (asyncLoad.progress < 0.9f)
        {
            yield return null;
        }

        StartCoroutine(WaitThenDoSomething());

        switchSceneButton.gameObject.SetActive(true);
        loadingText.gameObject.SetActive(false);
    }

    IEnumerator WaitThenDoSomething()
    {
        yield return new WaitForSeconds(2f);
    }

}
