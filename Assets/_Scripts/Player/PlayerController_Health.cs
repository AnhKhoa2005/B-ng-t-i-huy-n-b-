using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public partial class PlayerController : MonoBehaviour
{
    public void TakeDamage(float damage)
    {
        health -= damage;
        StartCoroutine(Hurt());
        if (health <= 0)
        {
            health = 0;
            GameManager.Instance.Coins = 0; // Reset coins on death
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reload current scene
        }
    }

    IEnumerator Hurt()
    {
        sr.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        sr.color = Color.white;
    }
}
