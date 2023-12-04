using UnityEngine;

public class CollisionSound : MonoBehaviour
{
    public AudioSource audioSource;
    public float minCollisionMagnitude = 0.1f;
    public float maxCollisionMagnitude = 1.0f;

    private void OnCollisionEnter(Collision collision)
    {
        float collisionMagnitude = collision.relativeVelocity.magnitude;

       
        float normalizedVolume = Mathf.InverseLerp(minCollisionMagnitude, maxCollisionMagnitude, collisionMagnitude);
        audioSource.volume = normalizedVolume;

        
        audioSource.Play();
    }
}

