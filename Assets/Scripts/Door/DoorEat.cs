using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorEat : MonoBehaviour
{
    private HungerMeter hungerBar;

    private void Start()
    {
        hungerBar = GameObject.FindAnyObjectByType<HungerMeter>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Pickup"))
        {
            if (other.GetComponent<PickupObject>().isHeld == false)
            {
                hungerBar.DecreaseHunger(other.gameObject.GetComponent<PickupObject>().eatValue);
                Destroy(other.gameObject);
            }
        }
    }
}
