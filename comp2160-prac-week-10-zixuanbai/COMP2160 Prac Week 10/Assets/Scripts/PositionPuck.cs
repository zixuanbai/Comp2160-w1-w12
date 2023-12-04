

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PositionPuck : MonoBehaviour
{
    private PlayerActions playerActions;
    private InputAction movePuck;
    private Rigidbody rigidbody;

    void Awake()
    {
        playerActions = new PlayerActions();
        movePuck = playerActions.PuckControl.MovePuck;
    }

    void OnEnable()
    {
        movePuck.Enable();
    }

    void OnDisable()
    {
        movePuck.Disable();
    }

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.isKinematic = false; 
    }

    void Update()
    {
        Vector3 position = mousePosition();
        rigidbody.position = position; 
    }

    private Vector3 mousePosition()
    {
        Plane plane = new Plane(Vector3.up, transform.position);
        Vector2 mouse = movePuck.ReadValue<Vector2>();
        Ray ray = Camera.main.ScreenPointToRay(mouse);
        float contact;
        plane.Raycast(ray, out contact);
        return ray.GetPoint(contact);
    }
}

