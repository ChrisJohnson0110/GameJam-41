using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyncWithMovement : MonoBehaviour
{
    [SerializeField] private GameObject movementBallRef;
    [SerializeField] private Vector3 modelOffset;
    [SerializeField] private float rotationSmooth;
    private PlayerMovement playerMovementRef;
    

    private void Start()
    {
        playerMovementRef = GameObject.FindAnyObjectByType<PlayerMovement>();
    }

    void Update()
    {
        gameObject.transform.position = movementBallRef.transform.position + modelOffset;
        if (playerMovementRef.inputDirection != Vector3.zero)
        {
            gameObject.transform.rotation = Quaternion.Lerp(gameObject.transform.rotation, Quaternion.LookRotation(-playerMovementRef.inputDirection), rotationSmooth);
        }
    }
}
