using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 6f;
    public float maxSpeed = 6f;
    private Rigidbody rb;
    private Vector3 inputDirection;

    void Update()
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
            rb.velocity = Vector3.Lerp(rb.velocity, Vector3.zero, 0.01f);
        }
        else
        {
            Vector3 desiredForce = inputDirection * moveSpeed;
            desiredForce = Vector3.ClampMagnitude(desiredForce, maxSpeed);
            rb.AddForce(desiredForce, ForceMode.Force);
        }

    }


}