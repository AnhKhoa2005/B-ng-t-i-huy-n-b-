using Unity.Collections;
using UnityEngine;

public class Bow : MonoBehaviour
{
    [SerializeField] Transform firePosition;
    [SerializeField] GameObject arrowPrefab;
    [SerializeField] float arrowSpeed = 10f;
    [SerializeField] float damage = 10f;
    Vector3 xDir;

    public void FireArrow(Vector3 xDir)
    {
         this.xDir = xDir;
        GameObject arrow = Instantiate(arrowPrefab, firePosition.position, Quaternion.identity);
        arrow.GetComponent<Arrow>().Init(arrowSpeed, damage, xDir);
        Destroy(arrow, 2f);
    }

}
