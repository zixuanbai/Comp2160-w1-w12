using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5.0f;
    public float MoveSpeed
    {
        get { return moveSpeed; }
        set { moveSpeed = value; }
    }


    private void Update()
    {
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime, Space.Self);
    }

}


