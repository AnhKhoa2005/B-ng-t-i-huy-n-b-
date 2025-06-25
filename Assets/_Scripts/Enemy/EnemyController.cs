using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour, ITakeDamage
{
    [SerializeField] float health = 100f;
    [SerializeField] float damage = 10f;

    [SerializeField] Transform pointA;
    [SerializeField] Transform pointB;
    [SerializeField] float moveSpeed = 2f;
    [SerializeField] float chaseRange = 5f;
    [SerializeField] Transform player;

    SpriteRenderer sr;
    Vector3 targetPos;
    bool chasingPlayer = false;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        targetPos = pointB.position;
        transform.position = pointA.position;
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= chaseRange)
        {
            chasingPlayer = true;
            // Giữ nguyên Y, chỉ thay đổi X theo player
            targetPos = new Vector3(player.position.x, transform.position.y, transform.position.z);
        }
        else
        {
            if (chasingPlayer)
            {
                chasingPlayer = false;
                float distToA = Vector3.Distance(transform.position, pointA.position);
                float distToB = Vector3.Distance(transform.position, pointB.position);
                targetPos = distToA < distToB ? pointB.position : pointA.position;
            }
        }

        MoveTowardsTarget();
    }

    void MoveTowardsTarget()
    {
        // Chỉ di chuyển trên trục X, giữ nguyên Y và Z
        Vector3 newTargetPos = new Vector3(targetPos.x, transform.position.y, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, newTargetPos, moveSpeed * Time.deltaTime);

        if (!chasingPlayer)
        {
            if (Mathf.Abs(transform.position.x - targetPos.x) < 0.1f)
            {
                targetPos = targetPos == pointA.position ? pointB.position : pointA.position;
            }
        }

        // Xoay theo hướng di chuyển (trục X)
        float directionX = newTargetPos.x - transform.position.x;
        if (directionX > 0.01f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (directionX < -0.01f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        StartCoroutine(Hurt());
        if (health <= 0)
        {
            GameManager.Instance.Score += 10;
            Destroy(gameObject);
        }
    }

    IEnumerator Hurt()
    {
        sr.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        sr.color = Color.white;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.GetComponent<ITakeDamage>() != null)
        {
            col.GetComponent<ITakeDamage>().TakeDamage(damage);
        }
    }
}
