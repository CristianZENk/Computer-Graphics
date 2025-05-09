using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 1000f;
    public float jumpForce = 7f;
    public int maxJumps = 2; // Permite double jump

    private Rigidbody rb;
    private int jumpCount = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // Blochează rotația pe X și Z pentru a preveni răsturnarea
        rb.freezeRotation = false;
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
    }

    void Update()
    {
        // Double jump
        if (Input.GetButtonDown("Jump") && jumpCount < maxJumps)
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z); // Resetează viteza pe Y pentru sărituri consistente
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jumpCount++;
        }
    }

    void FixedUpdate()
    {
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = transform.forward * moveVertical * moveSpeed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + movement);

        float turn = Input.GetAxis("Horizontal") * rotationSpeed * Time.fixedDeltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
        rb.MoveRotation(rb.rotation * turnRotation);
    }

    void OnCollisionEnter(Collision collision)
    {
        // Resetează săriturile doar dacă atinge solul
        if (collision.contacts[0].normal.y > 0.5f)
        {
            jumpCount = 0;
        }
    }
}
