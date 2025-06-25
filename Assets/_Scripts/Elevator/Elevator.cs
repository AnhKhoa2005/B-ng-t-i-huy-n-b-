using UnityEngine;

public class Elevator : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D col)
    {

        if (col.CompareTag("Player"))
        {
            col.GetComponent<PlayerController>().isClimbing = true;
        }

    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            col.GetComponent<PlayerController>().isClimbing = false;
        }
    }
}
