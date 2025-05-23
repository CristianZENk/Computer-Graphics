using UnityEngine;

public class Teleportto : MonoBehaviour
{
    [SerializeField] private Vector3 teleportCoordinates = new Vector3(0, 1, -9); // Set default teleport coordinates

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the zone is the player
        if (other.CompareTag("Player"))
        {
            // Teleport the player to the specified coordinates
            other.transform.position = teleportCoordinates;

            // Optional: Reset the player's velocity to prevent falling through
            Rigidbody playerRigidbody = other.GetComponent<Rigidbody>();
            if (playerRigidbody != null)
            {
                playerRigidbody.linearVelocity = Vector3.zero;
            }
        }
    }
}
