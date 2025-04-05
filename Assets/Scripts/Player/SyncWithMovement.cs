using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyncWithMovement : MonoBehaviour
{
    [SerializeField] private GameObject movementBallRef;
    [SerializeField] private Vector3 modelOffset;
    [SerializeField] private float rotationSmooth;
    private PlayerMovement playerMovementRef;

    private Vector3 startingScale;
    [SerializeField] private Vector3 big;
    [SerializeField] private Vector3 small;

    private bool playAnim = false;

    private void Start()
    {
        playerMovementRef = GameObject.FindAnyObjectByType<PlayerMovement>();
        startingScale = transform.localScale;
    }

    void Update()
    {
        gameObject.transform.position = movementBallRef.transform.position + modelOffset;
        if (playerMovementRef.inputDirection != Vector3.zero)
        {
            gameObject.transform.rotation = Quaternion.Lerp(gameObject.transform.rotation, Quaternion.LookRotation(-playerMovementRef.inputDirection), rotationSmooth);
            //playAnim = true;
            //StartCoroutine(MoveAnimation());
        }
        else
        {
            //transform.localScale = startingScale;
            //playAnim = false;
        }
        if(playerMovementRef.GetComponent<Rigidbody>().velocity.magnitude > 1f)
        {
            playAnim = true;
            StartCoroutine(MoveAnimation());
        }
        else
        {
            playAnim = false;
        }
    }


    private IEnumerator MoveAnimation()
    {
        while (playAnim)
        {
            float time = 0f;
            while (time < 0.2f)
            {
                float t = time / 0.2f;
                transform.localScale = Vector3.Lerp(startingScale, big, t);
                time += Time.deltaTime;
                yield return null;
            }
            time = 0f;
            while (time < 0.2f)
            {
                float t = time / 0.2f;
                transform.localScale = Vector3.Lerp(big, small, t);
                time += Time.deltaTime;
                yield return null;
            }
            time = 0f;
            while (time < 0.2f)
            {
                float t = time / 0.2f;
                transform.localScale = Vector3.Lerp(small, startingScale, t);
                time += Time.deltaTime;
                yield return null;
            }
        }
    }
}
