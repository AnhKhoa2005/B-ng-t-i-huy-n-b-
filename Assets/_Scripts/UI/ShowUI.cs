using UnityEngine;

public class ShowUI : MonoBehaviour
{
    public enum UIType
    {
        Background = 0,
        MainMenu = 1,
        Setting = 2,
        InGame = 3,
        Pause = 4,
        Win = 5
    }

    [SerializeField] public UIType type;

    private GameManager gameManager;

    private void Awake()
    {
    }
    private void Start()
    {
        gameManager = GameManager.Instance;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (type == UIType.InGame)
            {
                type = UIType.Pause;
            }
            else if (type == UIType.Pause)
            {
                type = UIType.InGame;
            }
        }

    }
    public void ShowUIButton()
    {
        foreach (GameObject ui in gameManager.UIs)
        {
            ui.SetActive(false);
        }

        if (type == UIType.MainMenu)
        {
            gameManager.UIs[(int)UIType.MainMenu].SetActive(true);
            gameManager.UIs[(int)UIType.Background].SetActive(true);
            Time.timeScale = 1f; // Pause the game
        }
        else if (type == UIType.Setting)
        {
            gameManager.UIs[(int)UIType.Setting].SetActive(true);
            gameManager.UIs[(int)UIType.Background].SetActive(true);
            Time.timeScale = 1f; // Pause the game
        }
        else if (type == UIType.InGame)
        {
            gameManager.UIs[(int)UIType.InGame].SetActive(true);
            Time.timeScale = 1f; // Resume the game
        }
        else if (type == UIType.Pause)
        {
            gameManager.UIs[(int)UIType.Pause].SetActive(true);
            Time.timeScale = 0f; // Pause the game
        }
        else if (type == UIType.Win)
        {
            gameManager.UIs[(int)UIType.Win].SetActive(true);
            Time.timeScale = 0f; // Resume the game
        }
    }
}
