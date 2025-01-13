using UnityEngine;

public class BaeController : MonoBehaviour
{
    public float speed = 1f;
    public float turn_speed = 1f;
    Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        // get horizontal linearvelity magnitude
        float hm = new Vector3(rb.linearVelocity.x, 0, rb.linearVelocity.z).magnitude;
        rb.AddRelativeForce(Vector3.forward * (speed - hm), ForceMode.VelocityChange);

        // apply torque to turn
        rb.angularVelocity = new Vector3(0, turn_speed, 0);
    }
}
