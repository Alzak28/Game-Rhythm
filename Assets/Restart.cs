using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    public void RestartGame()
    {
        // Muat ulang scene permainan
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        // Keluar dari aplikasi (hanya berfungsi di build, tidak di editor Unity)
        Application.Quit();
        Debug.Log("Game Quit"); // Debug log untuk editor
    }
}
