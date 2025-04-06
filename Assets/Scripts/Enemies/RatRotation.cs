using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatRotation : MonoBehaviour
{
    private Vector3 movementVector;
    private Vector3 lastPosition;

    // Update is called once per frame
    void Update()
    {
        movementVector = transform.position - lastPosition;
        lastPosition = transform.position;

        Vector3 movementDirection = movementVector.normalized;

        // Rotate 90 degrees to the left (around Y-axis)
        Vector3 rotatedDirection = Quaternion.Euler(0, -90, 0) * movementDirection;

        if (rotatedDirection != Vector3.zero)
        {
            gameObject.transform.localRotation = Quaternion.LookRotation(rotatedDirection, Vector3.up);
        }
    }
}
