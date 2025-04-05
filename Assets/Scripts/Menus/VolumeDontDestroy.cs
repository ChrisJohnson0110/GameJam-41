using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeDontDestroy : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
