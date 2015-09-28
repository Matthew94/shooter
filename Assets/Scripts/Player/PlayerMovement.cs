using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;

    public float speed = 6.0f;
    public float sprintMultiplier = 2f;
    public float gravity = 9.81f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Getting the raw move data
        var moveDirection = new Vector3(
            Input.GetAxis(AxisCodes.Horizontal), 
            0, 
            Input.GetAxis(AxisCodes.Vertical));

        // Local -> World Space
        moveDirection = transform.TransformDirection(moveDirection);

        // Applying the player's speed
        moveDirection *= speed;

        // Applying gravity to the vertical vector
        moveDirection.y -= gravity;

        // Clamping possible diagonal movement
        moveDirection = Vector3.ClampMagnitude(moveDirection, speed);

        // Applying sprint if needed
        var sprint = Input.GetAxis(AxisCodes.Sprint) * sprintMultiplier;

        if (sprint != 0)
        {
            moveDirection *= sprintMultiplier;
        }

        // Adapting for framerate changes
        moveDirection *= Time.deltaTime;

        // Moving
        controller.Move(moveDirection);
    }
}
