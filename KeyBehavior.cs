using UnityEngine;

public class KeyBehavior : MonoBehaviour
{
    private void Start()
    {
        // Ensure the key has a Rigidbody and Collider
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody>();
        }

        // Set Rigidbody properties to prevent falling through
        rb.useGravity = true; // Enable gravity
        rb.isKinematic = false; // Allow physics interactions
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous; // Prevent tunneling through objects

        // Ensure the key has a Collider
        if (GetComponent<Collider>() == null)
        {
            gameObject.AddComponent<BoxCollider>(); // Add a default BoxCollider if none exists
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Optional: Ensure the key stays on the plane
        if (collision.gameObject.CompareTag("Ground"))
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.linearVelocity = Vector3.zero; // Stop any downward movement
            }
        }
    }
}
