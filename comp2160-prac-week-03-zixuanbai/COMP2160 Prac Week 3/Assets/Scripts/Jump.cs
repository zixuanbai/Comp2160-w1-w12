using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Jump : MonoBehaviour
{
    private PlayerActions actions;
    private InputAction jumpAction;
    private enum JumpState
    {
        Jumping,
        OnGround,
    }
    private JumpState jumpState;
    [Range(0, 10)] [SerializeField] private float jumpSpeed;
    [Range(0, 10)] [SerializeField] private float gravity;
    private float speed;

    void Awake()
    {
        actions = new PlayerActions();
        jumpAction = actions.movement.jump;
        jumpState = JumpState.OnGround;
        speed = 0.0f;
    }
    void OnEnable()
    {
        jumpAction.Enable();
    }
    void OnDisable()
    {
        jumpAction.Disable();
    }
    void Update()
    {
        switch (jumpState)
        {
            case JumpState.OnGround:
                speed = 0;
                if (jumpAction.ReadValue<float>() > 0)
                {
                    jumpState = JumpState.Jumping;
                    speed = jumpSpeed;
                }
                break;

            case JumpState.Jumping:
                HandleJumping();
                break;
        }

        Vector3 moveDirection = new Vector3(0, speed, 0);
        transform.Translate(moveDirection * Time.deltaTime);
    }



    private void HandleOnGround()
    {
        if (jumpAction.triggered)
        {
            jumpState = JumpState.Jumping;
            speed = jumpSpeed;
        }
    }

    private void HandleJumping()
    {
        speed -= gravity * Time.deltaTime;

        Vector3 moveDirection = new Vector3(0, speed, 0);
        transform.Translate(moveDirection * Time.deltaTime);

        if (transform.position.y <= 0)
        {
            Vector3 newPosition = new Vector3(transform.position.x, 0, transform.position.z);
            transform.position = newPosition;
            jumpState = JumpState.OnGround;
            speed = 0.0f;
        }
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        {
            Destroy(gameObject); 
        }
    }

}
