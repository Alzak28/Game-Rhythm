using UnityEngine;
using UnityEngine.SceneManagement;

public class AutoMoveRigidbody : MonoBehaviour
{
    public float forwardSpeed = 10f; // Kecepatan maju
    public float lateralSpeed = 5f; // Kecepatan samping
    public float fallThreshold = 0f; // Ambang batas jatuh
    public float gravityMultiplier = 2f; // Pengali gravitasi agar jatuh lebih cepat

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; // Mencegah rotasi bola
        rb.useGravity = true; // Pastikan gravitasi Unity aktif
    }

    void Update()
    {
        // Tetapkan kecepatan bola ke depan
        Vector3 velocity = Vector3.forward * forwardSpeed;

        // Gerakan lateral (kanan/kiri)
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            velocity += Vector3.left * lateralSpeed;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            velocity += Vector3.right * lateralSpeed;
        }

        // Tetapkan kecepatan horizontal pada Rigidbody
        rb.velocity = new Vector3(velocity.x, rb.velocity.y, velocity.z);

        // Logika Jatuh dari Arena
        if (transform.position.y < fallThreshold)
        {
            Debug.Log("Bola jatuh dari arena! Game Over.");
            SceneManager.LoadScene("GameOver"); // Pastikan nama scene "GameOver" ada di Build Settings
        }
    }

    private void FixedUpdate()
    {
        // Tambahkan gravitasi tambahan untuk mempercepat jatuh
        rb.AddForce(Physics.gravity * gravityMultiplier, ForceMode.Acceleration);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            // Logika kalah jika menabrak obstacle
            Debug.Log("Bola menabrak obstacle!");
            Destroy(gameObject); // Hancurkan bola
            SceneManager.LoadScene("GameOver"); // Pindah ke scene Game Over
        }
        else if (other.CompareTag("Finish"))
        {
            // Logika menang jika mencapai garis finish
            Debug.Log("Bola mencapai garis finish!");
            SceneManager.LoadScene("StartGame"); // Pindah ke scene awal atau kemenangan
        }
    }
}
