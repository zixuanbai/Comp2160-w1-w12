using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Drive : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float turningRate;
    [SerializeField] private float turboSpeedMultiplier;
    [SerializeField] private float boostRate;
    private PlayerActions actions;
    private InputAction movementAction;
    private InputAction turboAction; 
    private Vector3 direction = new Vector3(0, 0, 1);
    private float boost; 

    void Awake()
    {
        actions = new PlayerActions();
        movementAction = actions.driving.movement;
        turboAction = actions.driving.turbo;
        turboAction.performed += OnTurbo;
        
    }

    void OnEnable()
    {
        movementAction.Enable();


        turboAction.Enable();
    }

    void OnDisable()
    {
        movementAction.Disable();

  
        turboAction.Disable();
    }

    void Update()
    {
        float horizontalInput = movementAction.ReadValue<Vector2>().x;
        float verticalInput = movementAction.ReadValue<Vector2>().y;


        transform.Translate(Vector3.right * speed * horizontalInput * Time.deltaTime);


        float newSpeed = speed + verticalInput;
        transform.Translate(Vector3.forward * newSpeed * Time.deltaTime, Space.Self);


        if (horizontalInput < 0)
        {
            
            transform.Rotate(Vector3.up, -turningRate * Time.deltaTime);
        }
        else if (horizontalInput > 0)
        {
            
            transform.Rotate(Vector3.up, turningRate * Time.deltaTime);
        }


        if (turboAction.triggered)
        {
            boost = boostRate; 
            newSpeed *= turboSpeedMultiplier;
        }
        if (turboAction.triggered)
        {
            boost = boostRate;
        }
        else
        {
            boost = 0.0f; 
        }
        float finalSpeed = newSpeed + (boost * turboSpeedMultiplier); 
        transform.Translate(Vector3.forward * finalSpeed * Time.deltaTime, Space.Self);
    }

    
    void OnTurbo(InputAction.CallbackContext context)
    {
        boost = boostRate;
    }
}