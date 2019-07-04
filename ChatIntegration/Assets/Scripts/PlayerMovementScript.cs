using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{

    public GameObject mainCamera;

    //editable values for twitch chat
    private float movementSpeed;
    private float horizontalSensitivity;
    private float verticalSensitivity;
    private float jumpSpeed;

    // Start is called before the first frame update
    void Start()
    {
        movementSpeed = 1f;
        jumpSpeed = 1f;
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
        Vector3 movement = new Vector3(horizontal*movementSpeed,0,vertical*movementSpeed);
    }

    void rotateCharacter()
    {
        float horizontal = Input.GetAxisRaw("Mouse X");
        Vector2 horizontalRotation = new Vector2(0,horizontal*horizontalSensitivity);
        transform.eulerAngles = horizontalRotation;
        float vertical = Input.GetAxisRaw("Mouse Y");
        Vector2 verticalRotation = new Vector2(vertical*verticalSensitivity,0);
        mainCamera.transform.eulerAngles = verticalRotation;
        
    }

    void UpdatePlayerSettings()
    {
        //This method changes the values to the player set values
    }
}
