using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyOnLoadPlayer : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            //gameObject.transform.GetChild(i).gameObject.SetActive(false);
            if (gameObject.transform.GetChild(i).GetComponent<Rigidbody>() != null)
            {
                gameObject.transform.GetChild(i).GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            }
        }
    }

    public void SceneChanged()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            //gameObject.transform.GetChild(i).gameObject.SetActive(true);
            if (gameObject.transform.GetChild(i).GetComponent<Rigidbody>() != null)
            {
                gameObject.transform.GetChild(i).GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            }
        }
    }
}
