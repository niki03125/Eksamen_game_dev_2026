using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    
    [SerializeField] private Transform cameraTransform;
    [SerializeField]float speed = 3f;
    //float jumpForce = 1.5f;
    [SerializeField]float gravity = -9.81f;
    [SerializeField]float mouseSpeed = 90f;
    
    // Stored seperatley so vertical look can be clamped.
    float xRotation = 0f;
    
    // Tracks vertical movement for gravity.
    float verticalVelocity = 0f;
    
    
    CharacterController controller;
    
    void Start()
    {
        
        controller = GetComponent<CharacterController>();
        // Lock cursor for fps camera control.
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    
    void Update()
    {
        Move();
        Look();
    }

    void Move()
    {
        float z = 0;
        float x = 0;

        
        if (Keyboard.current.wKey.isPressed) z = 1;
        if (Keyboard.current.sKey.isPressed) z = -1;

        
        if (Keyboard.current.dKey.isPressed) x = 1;
        if (Keyboard.current.aKey.isPressed) x = -1;
        
        
        Vector3 movementVector = transform.right * x + transform.forward * z;
        
        // Keeps the controller grounded instead of continuously building downwards speed.
        if(controller.isGrounded && verticalVelocity < 0)
        {
            verticalVelocity = -2f;
        }
        
        
        //if (Keyboard.current.spaceKey.isPressed && controller.isGrounded)
        //{
        //    verticalVelocity = Mathf.Sqrt(jumpForce * -2f * gravity);
        //}
        
        
        verticalVelocity += gravity * Time.deltaTime;

        
        Vector3 velocity = movementVector * speed;
        
        
        velocity.y = verticalVelocity;
        
        
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
