using UnityEngine;

public class NewMovement : MonoBehaviour
{
    public float dir = 0f;
    public float spinSpeed = 0f;
    public float moveSpeed = 0f;

    void Update()
    {
        // Make rotation
        transform.Rotate(Vector3.up * spinSpeed * dir * Time.deltaTime, Space.Self);
        // Calculate forward motion
        Vector3 motion = Vector3.forward * moveSpeed * Time.deltaTime;
        // Apply forward motion
        transform.Translate(motion, Space.Self);
    }
}
