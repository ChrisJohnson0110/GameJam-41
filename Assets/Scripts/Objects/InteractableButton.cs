using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableButton : MonoBehaviour
{
    [SerializeField] private SpawningMachine spawningMachineRef;

    private bool isInRange = false;

    private Vector3 originalScale;
    [SerializeField] private Vector3 targetScale;
    [SerializeField] private float animationDuration;

    [SerializeField] private GameObject buttonObject;

    private void Start()
    {
        originalScale = gameObject.transform.localScale;
    }

    private void Update()
    {
        if (isInRange == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                spawningMachineRef.SpawnObejcts();
                buttonObject.transform.localScale = Vector3.Lerp(originalScale, targetScale, animationDuration);
            }
        }
    }

    public void ReturnToScale()
    {
        buttonObject.transform.localScale = originalScale;
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
