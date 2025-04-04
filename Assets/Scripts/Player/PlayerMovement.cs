using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 6f;
    public float maxSpeed = 6f;
    private Rigidbody rb;
    private Vector3 inputDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
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

        //inputDirection = new Vector3(h, 0, v).normalized;
        inputDirection = (h * right) + (v * forward);

        if (inputDirection == Vector3.zero)
        {
            rb.velocity = Vector3.Lerp(rb.velocity, Vector3.zero, 0.001f);
        }
        else
        {
            Vector3 desiredForce = inputDirection * moveSpeed;
            desiredForce = Vector3.ClampMagnitude(desiredForce, maxSpeed);
            rb.AddForce(desiredForce, ForceMode.Force);
        }

    }

    private void GroundCheck()
    {
        Ray ray = new Ray(transform.position, Vector3.down);

        float rayDistance = 10f; // How far down to check

        if (Physics.Raycast(ray, out RaycastHit hit, rayDistance))
        {

        }
        else
        {
            rb.AddForce(new Vector3(0, -50000, 0), ForceMode.Force);
        }
    }

}