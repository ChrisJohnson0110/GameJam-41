using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPickup : MonoBehaviour
{
    private Rigidbody heldObjectRb;
    private FixedJoint joint;

    private GameObject objectToPickup;
    private bool isInRange = false;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (heldObjectRb != null)
            {
                Drop();
            }
            else
            {
                if (isInRange == true)
                {
                    Pickup();
                }
            }
        }
    }

    private void Pickup()
    {
        Rigidbody rb = objectToPickup.GetComponent<Rigidbody>();
        if (rb != null && !rb.isKinematic)
        {
            heldObjectRb = rb;

            joint = gameObject.AddComponent<FixedJoint>();
            joint.connectedBody = heldObjectRb;
            heldObjectRb.GetComponent<PickupObject>().isHeld = true;
        }
    }

    private void Drop()
    {
        if (joint != null)
        {
            Destroy(joint);
        }
        heldObjectRb.GetComponent<PickupObject>().isHeld = false;
        heldObjectRb = null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Pickup"))
        {
            isInRange = true;
            objectToPickup = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Pickup"))
        {
            isInRange = false;
            objectToPickup = null;
        }
    }
}
