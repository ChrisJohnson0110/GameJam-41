using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    private List<GameObject> pickupObjects = new List<GameObject>();
    [HideInInspector] public  GameObject targetObject;
    [SerializeField] private GameObject mouseHole;
    [SerializeField] private float speed;
    [HideInInspector] public FixedJoint joint;

    public Vector2 roomMinBounds = new Vector2(-5f, -5f);
    public Vector2 roomMaxBounds = new Vector2(5f, 5f);
    private Vector3 targetPosition;

    private void FixedUpdate()
    {
        if (targetObject == null) //if no target get one
        {
            GetNearest();

            if (targetObject == null && joint == null)
            {
                MoveToRandom();
            }
        }
        else
        {
            if (joint != null) //if connected to object, take it to hole
            {
                MoveToHole();
            }
            else //if not connected move to object
            {
                MoveToTarget();
            }

           if (targetObject.gameObject.GetComponent<PickupObject>().isHeld == true)
           {
               Disconnect();
           }
        }
    }

    private void GetNearest()
    {
        pickupObjects = new List<GameObject>();

        foreach (PickupObject g in GameObject.FindObjectsOfType<PickupObject>())
        {
            if (g.gameObject.transform.localPosition.y < 2.5f)
            {
                if (g.GetComponent<PickupObject>().isHeld == false)
                {
                    pickupObjects.Add(g.gameObject);
                }
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

    private void MoveToHole()
    {
        transform.position = Vector3.MoveTowards(gameObject.transform.position, mouseHole.transform.position, speed);
        transform.position = new Vector3(transform.position.x, 0.26f, transform.position.z);
    }

    private void MoveToTarget()
    {
        transform.position = Vector3.MoveTowards(gameObject.transform.position, targetObject.transform.position, speed);
        transform.position = new Vector3(transform.position.x, 0.26f, transform.position.z);
    }
    private void MoveToRandom()
    {
        if (targetPosition == Vector3.zero)
        {
            targetPosition = new Vector3(
                Random.Range(roomMinBounds.x, roomMaxBounds.x),
                transform.position.y, // Keep same Y height
                Random.Range(roomMinBounds.y, roomMaxBounds.y)
            );
        }
        if (Vector3.Distance(transform.position, targetPosition) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(gameObject.transform.position, targetPosition, speed);
            transform.position = new Vector3(transform.position.x, 0.26f, transform.position.z);
        }
        else
        {
            targetPosition = Vector3.zero;
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
                    Connect();
                }
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<PickupObject>())
        {
            if (targetObject != null)
            {
                if (other.gameObject == targetObject)
                {
                    Connect();
                }
            }
        }
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(2);
    }



    private void Connect()
    {
        //StartCoroutine(Delay()); //add before move

        if (targetObject != null)
        {
            if (targetObject.GetComponent<PickupObject>().isHeld == false)
            {
                //make a joint connection to the object
                if (joint == null)
                {
                    Rigidbody rb = targetObject.GetComponent<Rigidbody>();
                    if (rb != null && !rb.isKinematic)
                    {
                        joint = gameObject.AddComponent<FixedJoint>();
                        joint.connectedBody = targetObject.gameObject.GetComponent<Rigidbody>();
                    }
                    targetObject.GetComponent<PickupObject>().isRat = true;
                }
            }
        }
    }

    public void Disconnect()
    {
        pickupObjects.Remove(targetObject);
        targetObject.GetComponent<PickupObject>().isRat = false;
        targetObject = null;

        if (joint != null)
        {
            Destroy(joint);
        }
    }
}
