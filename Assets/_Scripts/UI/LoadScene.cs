using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadScene : MonoBehaviour
{
    private enum SceneName
    {
        MainMenu,
        Level_1,
    }

    [SerializeField] private SceneName sceneName;
    public void LoadGame()
    {
        switch (sceneName)
        {
            case SceneName.MainMenu:
                SceneManager.LoadScene("MainMenu");
                break;
            case SceneName.Level_1:
                SceneManager.LoadScene("Level_1");
                break;
            default:
                Debug.LogError("Scene not found: " + sceneName);
                break;
        }
    }

}
