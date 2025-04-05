using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPickup : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Pickup"))
        {
            other.GetComponent<PickupObject>().isHeld = false;
            Destroy(other.gameObject);
            foreach (Mouse go in GameObject.FindObjectsOfType<Mouse>())
            {
                go.Disconnect();
            }
            
        }
    }
}
