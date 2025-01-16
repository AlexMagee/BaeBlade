using UnityEngine;
using UnityEngine.Events;

public class BouncyObstacle : MonoBehaviour
{
    public float bounciness = 1f;
    public float up = 1f;
    public UnityEvent hitEvent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        Vector3 explosionCenter = collision.contacts[0].point;
        float explosionRadius = 5f;

        // Apply explosion force, but only in the horizontal direction (x, z)
        Vector3 direction = (collision.transform.position - explosionCenter).normalized;
        direction.y = up; // Ignore vertical component

        // Apply the horizontal force
        collision.rigidbody.AddForce(direction * bounciness, ForceMode.Impulse);
        collision.transform.GetComponent<BaeController>().grounded = false;
        collision.transform.GetComponent<AudioSource>().Play();
        // collision.rigidbody.AddForce((-collision.relativeVelocity.normalized + (Vector3.up * up)) * bounciness, ForceMode.Impulse);
        // collision.rigidbody.AddExplosionForce(bounciness, collision.contacts[0].point, 5);

        hitEvent.Invoke();
    }
}
