using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public void RestartGame()
    {
        // Muat ulang scene permainan
        SceneManager.LoadScene("StartGame");
    }
}