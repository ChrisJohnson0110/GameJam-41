using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorEat : MonoBehaviour
{
    [SerializeField] private GameObject doorObject;
    private HungerMeter hungerBar;

    private void Start()
    {
        hungerBar = GameObject.FindAnyObjectByType<HungerMeter>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Pickup"))
        {
            if (other.GetComponent<PickupObject>().isHeld == true)
            {
                hungerBar.DecreaseHunger(other.gameObject.GetComponent<PickupObject>().eatValue);
                Destroy(other.gameObject);
                GameObject.FindAnyObjectByType<EatAnimation>().Eat();
                doorObject.transform.localScale += (doorObject.transform.localScale * 0.02f);
                GameObject.FindObjectOfType<ObjectPickup>().Drop();
            }
        }
    }
}
