using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] float damage = 10f;
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.GetComponent<ITakeDamage>() != null)
        {
            col.GetComponent<ITakeDamage>().TakeDamage(damage);
        }
    }
}
