using UnityEngine;

public class Arrow : MonoBehaviour
{
    float arrowSpeed;
    float damage;
    Vector3 xDir;

    Rigidbody2D rb;
    Transform tf;

    public void Init(float arrowSpeed, float damage, Vector3 xDir) // Khởi tạo các properties của viên đạn nếu cần thiết
    {
        this.arrowSpeed = arrowSpeed;
        this.damage = damage;
        this.xDir = xDir;
      
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        ArrowForce();
    }

    void ArrowForce()
    {
        
        transform.localScale = xDir;
        rb.linearVelocity = new Vector2(xDir.x * arrowSpeed, 0f);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.GetComponent<ITakeDamage>() != null)
        {
            col.GetComponent<ITakeDamage>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
