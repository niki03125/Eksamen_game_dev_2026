using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    
    public Transform cameraTransform;
    float speed = 7f;
    float jumpForce = 1.5f;
    float gravity = -9.81f;
    float mouseSpeed = 100f;

    //For When saving looking up and down we need to save the rotation so we can clamp it and prevent the player from looking too far up or down.
    float xRotation = 0f;
    
    //Saving the players speed up and down and jump and the way down from jumping. we will use this to apply gravity and jumping.
    float verticalVelocity = 0f;
    
    
    CharacterController controller;
    
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // we get the character controller component so we can move the player. It is a function from unity (MonoBehavior).
        controller = GetComponent<CharacterController>();
        
        // we lock the cursor to the center of the screen and make it invisible. cursor is a static class in the unityEngine that controls the mouse and lockstate is a property.
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Look();
    }

    void Move()
    {
        float z = 0;
        float x = 0;

        // Forward and backward movement.
        if (Keyboard.current.wKey.isPressed) z = 1;
        if (Keyboard.current.sKey.isPressed) z = -1;

        // Left and right movement.
        if (Keyboard.current.dKey.isPressed) x = 1;
        if (Keyboard.current.aKey.isPressed) x = -1;
        
        //Vector3 holds x, y, z values. is used as an movementVector that descrips where the player has to move on this frame.
        Vector3 movementVector = transform.right * x + transform.forward * z;
        
        //If the player is on the ground and their vertical velocity is negative (falling), we set it to a small negative value to keep them grounded.
        if(controller.isGrounded && verticalVelocity < 0)
        {
            verticalVelocity = -2f;
        }
        
        
        if (Keyboard.current.spaceKey.isPressed && controller.isGrounded)
        {
            verticalVelocity = Mathf.Sqrt(jumpForce * -2f * gravity);
        }
        
        //Time.deltaTime = time since last frame. so the player can fall
        verticalVelocity += gravity * Time.deltaTime;

        //Describes the movement in the y direction (up and down) and we add it to the movement vector so we can apply gravity and jumping. vector to x and z.
        Vector3 velocity = movementVector * speed;
        
        //Combining the horizontal movement with the vertical movement. x, z and y.
        velocity.y = verticalVelocity;
        
        //Using the controller to move the player.
        controller.Move(velocity * Time.deltaTime);
    }

    void Look()
    {
        float mouseX = Mouse.current.delta.ReadValue().x * mouseSpeed * Time.deltaTime;
        float mouseY = Mouse.current.delta.ReadValue().y * mouseSpeed * Time.deltaTime;
        
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);
        
        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }
    
    
}
