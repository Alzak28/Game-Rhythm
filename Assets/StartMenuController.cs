using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuController : MonoBehaviour
{
    public void StartGame()
    {
        // Ganti "NamaScenePermainan" dengan nama scene permainan Anda
        SceneManager.LoadScene("SampleScene");
    }
}
