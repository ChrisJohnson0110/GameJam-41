using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPickup : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Pickup"))
        {
            if (other.gameObject.GetComponent<PickupObject>().isRat == true && other.gameObject.GetComponent<PickupObject>().isHeld == false)
            {
                other.GetComponent<PickupObject>().isRat = false;
                other.GetComponent<PickupObject>().isHeld = false;
                Destroy(other.gameObject);
                foreach (Mouse go in GameObject.FindObjectsOfType<Mouse>())
                {
                    go.Disconnect();
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Pickup"))
        {
            if (other.gameObject.GetComponent<PickupObject>().isRat == true && other.gameObject.GetComponent<PickupObject>().isHeld == false)
            {
                other.GetComponent<PickupObject>().isRat = false;
                other.GetComponent<PickupObject>().isHeld = false;

                Destroy(other.gameObject);
                foreach (Mouse go in GameObject.FindObjectsOfType<Mouse>())
                {
                    go.Disconnect();
                }
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Pickup"))
        {
            if (other.gameObject.GetComponent<PickupObject>().isRat == true && other.gameObject.GetComponent<PickupObject>().isHeld == false)
            {
                other.GetComponent<PickupObject>().isRat = false;
                other.GetComponent<PickupObject>().isHeld = false;

                Destroy(other.gameObject);
                foreach (Mouse go in GameObject.FindObjectsOfType<Mouse>())
                {
                    go.Disconnect();
                }
            }
        }
    }
}
