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

    void FixedUpdate()
    {
        Vector2 moveDirection = playerInput.actions["move"].ReadValue<Vector2>();

        // get horizontal linearvelity magnitude
        float hm = new Vector3(rb.linearVelocity.x, 0, rb.linearVelocity.z).magnitude;
        rb.AddRelativeForce(Vector3.forward * (speed - hm), ForceMode.VelocityChange);

        rb.angularVelocity = new Vector3(0, moveDirection.x * turnSpeed, 0);
    }
}
