using UnityEngine;

public class Coin : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            GameManager.Instance.Coins++;
            AudioManagers.Instance.SFXPlay(AudioManagers.Instance.CoinClip);
            Destroy(gameObject);
        }
    }
}
