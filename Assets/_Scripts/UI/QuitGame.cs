using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitGame : MonoBehaviour
{
    public void Quit()
    {
        Debug.Log("Quitting the game...");
        Application.Quit();
    }
}
