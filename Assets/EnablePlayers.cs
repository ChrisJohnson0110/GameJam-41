using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnablePlayers : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        foreach (DontDestroyOnLoadPlayer d in GameObject.FindObjectsOfType<DontDestroyOnLoadPlayer>())
        {
            d.SceneChanged();
        }
    }

}
