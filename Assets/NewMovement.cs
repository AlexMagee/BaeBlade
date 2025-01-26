using UnityEngine;
using UnityEngine.InputSystem;

public class NewMovement : MonoBehaviour
{
    public float spinSpeed = 0f;
    public float moveSpeed = 0f;

    void Update()
    {
        // Get gamepad reference
        Gamepad gamepad = Gamepad.current;
        if(gamepad == null)
        {
            return;
        }
        // Get move value
        Vector2 move = gamepad.leftStick.ReadValue();
        // Make rotation
        transform.Rotate(Vector3.up * spinSpeed * move.x * Time.deltaTime, Space.Self);
        // Calculate forward motion
        Vector3 motion = Vector3.forward * moveSpeed * ((move.y * 0.5f) + 1) * Time.deltaTime;
        // Apply forward motion
        transform.Translate(motion, Space.Self);
    }
}
