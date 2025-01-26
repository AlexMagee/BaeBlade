using UnityEngine;
using UnityEngine.InputSystem;

public class NewMovement : MonoBehaviour
{
    public float spinSpeed = 0f;
    public float moveSpeed = 0f;
    private float angle = 0f;
    private CharacterController controller;
    private Transform cameraPivot;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        cameraPivot = transform.GetChild(0);
    }

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
        // Create rotation quaternion
        Quaternion _rot = Quaternion.AngleAxis((move.x * spinSpeed * Time.deltaTime) + angle, Vector3.up);
        // Create movement vector
        Vector3 _dir = _rot * Vector3.forward * moveSpeed * ((move.y * 0.5f) + 1) * Time.deltaTime;
        // Store angle for next update
        angle = _rot.eulerAngles.y;
        // Apply forward motion
        controller.Move(_dir);
        // Pivot camera
        cameraPivot.rotation = _rot;
    }
}
