using UnityEngine;
using UnityEngine.SceneManagement;

public class AutoMoveRigidbody : MonoBehaviour
{
    public float forwardSpeed = 10f; // Kecepatan maju
    public float lateralSpeed = 5f; // Kecepatan samping

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; // Mencegah rotasi
    }

    void Update()
    {
        // Tetapkan kecepatan langsung pada Rigidbody
        Vector3 velocity = Vector3.forward * forwardSpeed;

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            velocity += Vector3.left * lateralSpeed;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            velocity += Vector3.right * lateralSpeed;
        }

        rb.velocity = velocity;
    }

    public string obstacleTag = "Obstacle"; // Tag obstacle yang harus dideteksi

    private void OnCollisionEnter(Collision collision)
    {
        // Periksa apakah bola menabrak obstacle
        if (collision.gameObject.CompareTag(obstacleTag))
        {
            Debug.Log("Bola menabrak obstacle!");
            Destroy(gameObject); // Hancurkan bola
            SceneManager.LoadScene("GameOver"); // Pindah ke scene Game Over
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            // Logika untuk kalah
            Debug.Log("Kena obstacle!");
            Destroy(gameObject); // Hancurkan bola
            SceneManager.LoadScene("GameOver"); // Pindah ke scene Game Over
        }
        else if (other.CompareTag("Finish"))
        {
            // Logika untuk menang
            Debug.Log("Garis finish!");
            SceneManager.LoadScene("StartGame"); // Pindah ke scene kemenangan
        }
    }

}
