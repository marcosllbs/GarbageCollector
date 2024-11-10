using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenuScript : MonoBehaviour
{

    public void StartGame()
    {
        SceneManager.LoadScene("GameScreen");
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        // Para o editor do Unity
        EditorApplication.isPlaying = false;
#else
            // Para builds em dispositivos móveis, PC e consoles
            Application.Quit();
#endif
    }
}