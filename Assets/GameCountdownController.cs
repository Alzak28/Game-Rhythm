using System.Collections;
using UnityEngine;
using TMPro;

public class GameCountdownController : MonoBehaviour
{
    public TextMeshProUGUI countdownText; // Referensi ke UI Text TMP
    public int countdownTime = 3; // Waktu countdown dalam detik
    public GameObject player; // Referensi ke pemain
    public Rigidbody playerRigidbody; // Rigidbody pemain

    private void Start()
    {
        // Menonaktifkan gerakan pemain selama countdown
        playerRigidbody = player.GetComponent<Rigidbody>();
        playerRigidbody.isKinematic = true;

        // Memulai countdown
        StartCoroutine(CountdownCoroutine());
    }

    private IEnumerator CountdownCoroutine()
    {
        Debug.Log("Countdown started!"); // Log awal

        for (int i = countdownTime; i > 0; i--)
        {
            Debug.Log("Countdown: " + i); // Log angka countdown
            countdownText.text = i.ToString(); // Update UI countdown
            yield return new WaitForSeconds(1); // Tunggu 1 detik
        }

        Debug.Log("Countdown finished!");
        countdownText.text = "GO!"; // Tampilkan "GO!" setelah countdown selesai
        yield return new WaitForSeconds(0.5f); // Tahan sedikit

        countdownText.text = ""; // Kosongkan teks countdown
        StartGame(); // Mulai permainan
    }

    private void StartGame()
    {
        // Aktifkan kembali gerakan pemain setelah countdown selesai
        playerRigidbody.isKinematic = false;
        Debug.Log("Game Started!"); // Log untuk memastikan permainan dimulai
    }
}
