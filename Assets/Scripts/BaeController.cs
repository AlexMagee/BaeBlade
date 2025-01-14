using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class BaeController : MonoBehaviour
{
    public Transform mesh;
    PlayerInput playerInput;
    public float speed = 1f;
    public float turnSpeed = 1f;
    Rigidbody rb;

    public bool cap = true;
    public bool grounded = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float force = 10f;  // Energy output of the "flywheel"
    public float maxSpeed = 5f;       // Maximum speed (to cap runaway effects)
    public float stabilizationFactor = 0.5f; // Damping to resist external speed changes

    private void FixedUpdate()
    {
        Vector2 moveDirection = playerInput.actions["move"].ReadValue<Vector2>();

        // Get the velocity in the horizontal plane (ignore vertical component)
        Vector3 horizontalVelocity = new Vector3(rb.linearVelocity.x, 0, rb.linearVelocity.z);

        // Project the horizontal velocity onto the forward direction
        float forwardSpeed = Vector3.Dot(horizontalVelocity, transform.forward);

        // Stabilize speed (resist sudden changes from external forces)
        float speedError = maxSpeed - Mathf.Abs(forwardSpeed);
        Vector3 stabilizationForce = transform.forward * (speedError * stabilizationFactor);

        // Apply constant forward force
        Vector3 flywheelForce = transform.forward * force;

        // Combine forces: constant propulsion + stabilization
        if(grounded)
            rb.AddForce(flywheelForce + stabilizationForce, ForceMode.Force);

        // Cap the horizontal speed to avoid runaway motion
        if (grounded && horizontalVelocity.magnitude > maxSpeed)
        {
            // Scale horizontal velocity to the maxSpeed
            Vector3 cappedVelocity = horizontalVelocity.normalized * maxSpeed;

            // Preserve the original vertical velocity
            rb.linearVelocity = new Vector3(cappedVelocity.x, rb.linearVelocity.y, cappedVelocity.z);
        }

        rb.angularVelocity = new Vector3(0, moveDirection.x * turnSpeed, 0);
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.contacts[0].point.y < transform.position.y)
        {
            grounded = true;
            GetComponent<AudioSource>().Play();
        }
    }
}
