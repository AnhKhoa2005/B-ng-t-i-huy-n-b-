using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    private ShowUI showUI;
    private void Start()
    {
        showUI = GetComponent<ShowUI>();
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player") && GameManager.Instance.coins.childCount == 0 && SceneManager.GetActiveScene().name != "Level_3")
        {
            GameManager.Instance.Coins = 0;
            GameManager.Instance.Score = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else if (col.CompareTag("Player") && GameManager.Instance.coins.childCount == 0 && SceneManager.GetActiveScene().name == "Level_3")
        {
            showUI.type = ShowUI.UIType.Win;
            showUI.ShowUIButton();
        }
    }
}
