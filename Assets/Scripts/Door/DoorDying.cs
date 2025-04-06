using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorDying : MonoBehaviour
{
    [SerializeField] private Vector3 scale;

    void Update()
    {
        gameObject.transform.localScale -= scale * Time.deltaTime;
        if (transform.localScale.y <= 3)
        {
            Destroy(this.gameObject);
        }
    }
}
