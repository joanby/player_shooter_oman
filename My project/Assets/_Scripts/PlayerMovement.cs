using System;
using UnityEngine;
using UnityEngine.InputSystem;//THIS IS THE NEW INPUT SYSTEM

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;
    
    [SerializeField]
    private float rotationSpeed;

    private Vector2 movementValue;
    private float lookValue;

    private Rigidbody rb; //Because we want the player to move with physics


    private void Awake()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        rb = GetComponent<Rigidbody>();
    }


    public void OnMove(InputValue value) //value is the player doing things in real world
    {
        movementValue = value.Get<Vector2>();
    }
    public void OnLook(InputValue value)
    {
        lookValue = value.Get<Vector2>().x; //I only rotate in one direction
    }


    void Update()
    {

        /*if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }*/

        //dS = input * V * dt
        Vector2 translation = movementValue * speed * Time.deltaTime;
        float rotation = lookValue * rotationSpeed * Time.deltaTime;

        //MOVE PLAYER WITH PHYSICS
        rb.AddRelativeForce(translation.x, 0, translation.y);
        rb.AddRelativeTorque(0, rotation, 0);

        /*
         * MOVE PLAYER WITH STANDARD MOVEMENT
         * this.transform.Translate(translation.x, 0, translation.y); //player moves in XZ plane
         * this.transform.Rotate(0, rotation, 0);
        */


        //OLD INPUT SYSTEM -> DEPRECATED IN NEW VERSIONS
        /*if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            this.transform.Translate(0, 0, speed * Time.deltaTime);
        }
        
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            this.transform.Translate(0, 0, -speed * Time.deltaTime);
        }
        
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.Translate(speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.Translate(-speed * Time.deltaTime, 0, 0);
        }*/
        
        //TODO: left and right with A/<- and D/->
        /*float mouseX = Input.GetAxis("Mouse X"); //float -1 to 1
        this.transform.Rotate(0,mouseX* rotationSpeed * Time.deltaTime,0);*/
    }
}
