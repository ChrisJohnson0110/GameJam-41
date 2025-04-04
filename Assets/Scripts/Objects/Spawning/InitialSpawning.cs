using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialSpawning : MonoBehaviour
{
    [SerializeField] private Transform pickupObjectHolder;
    [SerializeField] private List<GameObject> objectsToSpawn;
    [SerializeField] private int spawningRange;
    [SerializeField] private int numberToSpawn;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numberToSpawn; i++)
        {
            GameObject go = Instantiate(objectsToSpawn[Random.Range(0, objectsToSpawn.Count)], new Vector3(Random.Range(-spawningRange, spawningRange), 0, Random.Range(-spawningRange, spawningRange)), transform.rotation);
            go.transform.SetParent(pickupObjectHolder);
        }
    }

}
