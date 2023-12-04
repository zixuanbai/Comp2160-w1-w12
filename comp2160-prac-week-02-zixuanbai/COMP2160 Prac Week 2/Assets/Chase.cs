using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float minDistance;
    [SerializeField] private float speed = 5.0f;

    private void Start()
    {

    }

    private void Update()
    {
        float distanceToTarget = Vector3.Distance(transform.position, target.position);

        if (distanceToTarget > minDistance)
        {
            transform.LookAt(target);
            Vector3 targetLocalPosition = transform.InverseTransformPoint(target.position);

            if (targetLocalPosition.x < 0)
            {
                transform.Rotate(Vector3.up, -90.0f * Time.deltaTime);
            }
            else
            {
                transform.Rotate(Vector3.up, 90.0f * Time.deltaTime);
            }

            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }
}
