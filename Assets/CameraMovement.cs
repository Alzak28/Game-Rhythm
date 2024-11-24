using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        if (player != null) // Periksa apakah player masih ada
        {
            transform.position = new Vector3(
                transform.position.x,
                transform.position.y,
                player.transform.position.z - 8f
            );
        }
        else
        {
            Debug.Log("Player tidak ditemukan, kamera berhenti mengikuti.");
            // Anda bisa menambahkan logika lain di sini, misalnya mengunci kamera
        }
    }
}
