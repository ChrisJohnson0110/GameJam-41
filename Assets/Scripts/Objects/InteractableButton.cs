using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableButton : MonoBehaviour
{
    [SerializeField] private SpawningMachine spawningMachineRef;

    bool isInRange = false;

    private void Update()
    {
        if (isInRange == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                spawningMachineRef.SpawnObejcts();

            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            isInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            isInRange = false;
        }
    }
}
