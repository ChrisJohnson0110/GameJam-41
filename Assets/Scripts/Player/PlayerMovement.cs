using UnityEngine;
using TMPro;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 6f;
    public float maxSpeed = 6f;
    private Rigidbody rb;
    [HideInInspector] public Vector3 inputDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
            HandleMovement();
            GroundCheck();
    }

    private void HandleMovement()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 forward = Camera.main.transform.forward;
        Vector3 right = Camera.main.transform.right;

        forward.y = 0f;
        right.y = 0f;


        forward.Normalize();
        right.Normalize();

        inputDirection = (h * right) + (v * forward);
        inputDirection.Normalize();

        if (inputDirection == Vector3.zero)
        {
            rb.velocity = Vector3.Lerp(rb.velocity, Vector3.zero, 0.01f);
        }
        else
        {
            Vector3 desiredForce = inputDirection * moveSpeed;
            desiredForce = Vector3.ClampMagnitude(desiredForce, maxSpeed);
            rb.AddForce(desiredForce, ForceMode.Acceleration);
        }

        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
    }

    private void GroundCheck()
    {
        Ray ray = new Ray(transform.position, Vector3.down);

        float rayDistance = 10f;

        if (!Physics.Raycast(ray, out RaycastHit hit, rayDistance))
        {
            rb.AddForce(new Vector3(0, -5000, 0));
        }
    }

}