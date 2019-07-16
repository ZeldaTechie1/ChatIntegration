using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{

    public GameObject mainCamera;
    private float rotationClamp;
    private Quaternion rotation;
    Rigidbody rb;
    //editable values for twitch chat
    private float movementSpeed;
    private float horizontalSensitivity;
    private float verticalSensitivity;
    private float jumpSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rotation = transform.rotation;
        movementSpeed = 10f;
        jumpSpeed = 1f;
        rotationClamp = 80;//this restricts the camera from going upside down
        rb = GetComponent<Rigidbody>();
        //these default ones can be changed within the player settings
        horizontalSensitivity = 1f;
        verticalSensitivity = 1f;
        
        UpdatePlayerSettings();
    }

    // Update is called once per frame
    void Update()
    {
        move();
        rotateCharacter();
    }

    void move()//makes the character move
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 movement = Vector3.zero;
        movement += transform.right * horizontal*movementSpeed;
        movement += transform.forward * vertical * movementSpeed;
        movement.y = rb.velocity.y;

        rb.velocity = movement;

    }

    void rotateCharacter()
    {
        rotation.y += Input.GetAxis("Mouse X");
        rotation.x += -Input.GetAxis("Mouse Y");
        rotation.x = Mathf.Clamp(rotation.x, -rotationClamp, rotationClamp);

        transform.eulerAngles = new Vector2(0, rotation.y) * verticalSensitivity;
        mainCamera.transform.localRotation = Quaternion.Euler(rotation.x * horizontalSensitivity, 0, 0);

    }

    void UpdatePlayerSettings()
    {
        //This method changes the values to the player set values
    }
}
