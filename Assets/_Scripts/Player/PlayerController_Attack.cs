using UnityEngine;

public partial class PlayerController : MonoBehaviour
{
    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            bow.FireArrow(transform.localScale);
            AudioManagers.Instance.SFXPlay(AudioManagers.Instance.ShootClip);
        }
    }
}
