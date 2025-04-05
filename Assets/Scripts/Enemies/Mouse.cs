using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    private List<GameObject> pickupObjects = new List<GameObject>();
    private GameObject targetObject;
    [SerializeField] private GameObject mouseHole;
    [SerializeField] private float speed;
    private bool isTouchingTarget = false;
    [HideInInspector] public FixedJoint joint;

    private void Update()
    {
        if (isTouchingTarget == true) //move to hole
        {
            transform.position = Vector3.MoveTowards(gameObject.transform.position, mouseHole.transform.position, speed);
            transform.position = new Vector3(transform.position.x, 0.47f, transform.position.z);
        }
        else
        {
            if (targetObject == null)
            {
                foreach (PickupObject g in GameObject.FindObjectsOfType<PickupObject>())
                {
                    if (g.GetComponent<PickupObject>().isHeld == false)
                    {
                        pickupObjects.Add(g.gameObject);
                    }
                }
                foreach (GameObject go in pickupObjects) //get nearest
                {
                    if (targetObject == null)
                    {
                        targetObject = go;
                    }
                    else if (Vector3.Distance(gameObject.transform.position, go.transform.position) < Vector3.Distance(gameObject.transform.position, targetObject.transform.position))
                    {
                        targetObject = go;
                    }
                }
            }
            if (targetObject != null)
            {
                transform.position = Vector3.MoveTowards(gameObject.transform.position, targetObject.transform.position, speed);
                transform.position = new Vector3(transform.position.x, 0.47f, transform.position.z);
            }
        }
        if (targetObject != null)
        {
            if (targetObject.GetComponent<PickupObject>().isHeld == true)
            {
                pickupObjects.Remove(targetObject);
                targetObject = null;
                isTouchingTarget = false;
                if (joint != null)
                {
                    Destroy(joint);
                }

            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PickupObject>())
        {
            if (targetObject != null)
            {
                if (other.gameObject == targetObject)
                {
                    StartCoroutine(Delay(other.gameObject));
                }
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (targetObject == other.gameObject)
        {
            isTouchingTarget = true;
        }
    }

    IEnumerator Delay(GameObject target)
    {
        yield return new WaitForSeconds(2);

        if (targetObject != null)
        {
            if (targetObject.GetComponent<PickupObject>().isHeld == false)
            {
                if (isTouchingTarget == true)
                {
                    Rigidbody rb = target.GetComponent<Rigidbody>();
                    if (rb != null && !rb.isKinematic)
                    {
                        joint = gameObject.AddComponent<FixedJoint>();
                        joint.connectedBody = target.gameObject.GetComponent<Rigidbody>();
                    }
                }
                
            }
        }

        
    }



    private void Connect()
    {
        //make a joint connection to the object
        Rigidbody rb = target.GetComponent<Rigidbody>();
        if (rb != null && !rb.isKinematic)
        {
            joint = gameObject.AddComponent<FixedJoint>();
            joint.connectedBody = target.gameObject.GetComponent<Rigidbody>();
        }
    }

    private void Disconnect()
    {

    }
}
