using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningMachine : MonoBehaviour
{
    [SerializeField] private List<GameObject> objectsToThrow;
    private Transform spawnPostition;
    [SerializeField] private Vector3 spawnedObjectForce;
    [SerializeField] private Vector3 spawnedObjectOffset;
    [SerializeField] private int numberOfObjectsToSpawn = 5;

    [SerializeField] private int ButtonCooldown;
    private float cooldown = 0;
    private bool canSpawnObjects;

    [SerializeField] private Light buttonLight;

    private void Start()
    {
        spawnPostition = gameObject.transform.GetChild(0);
    }

    private void Update()
    {
        if (cooldown <= 0)
        {
            if (canSpawnObjects == false)
            {
                GameObject.FindObjectOfType<InteractableButton>().ReturnToScale();
                canSpawnObjects = true;
                buttonLight.color = Color.green;
            }
        }
        else
        {
            cooldown -= Time.deltaTime;
            buttonLight.color = Color.red;
        }
    }

    public void SpawnObejcts()
    {
        if (canSpawnObjects == true)
        {
            if (objectsToThrow != null)
            {
                for (int i = 0; i < numberOfObjectsToSpawn; i++)
                {
                    GameObject go = Instantiate(objectsToThrow[Random.Range(0, objectsToThrow.Count)], spawnPostition.position, spawnPostition.rotation);
                    if (go.GetComponent<Rigidbody>() == null)
                    {
                        go.AddComponent<Rigidbody>();
                    }

                    Vector3 ObjectForce = new Vector3(spawnedObjectForce.x + Random.Range(-spawnedObjectOffset.x, spawnedObjectOffset.x),
                                                      spawnedObjectForce.y + Random.Range(-spawnedObjectOffset.y, spawnedObjectOffset.y),
                                                      spawnedObjectForce.z + Random.Range(-spawnedObjectOffset.z, spawnedObjectOffset.z));

                    go.GetComponent<Rigidbody>().AddForce(ObjectForce);
                }
            }
            canSpawnObjects = false;
            cooldown = ButtonCooldown;
        }
    }
}
