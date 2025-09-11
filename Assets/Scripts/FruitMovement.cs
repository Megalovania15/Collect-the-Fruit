using UnityEngine;

public class FruitMovement : MonoBehaviour
{
    public float speed = 20f;

    private Vector2 currentDirection;

    private Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        Move();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        
    }

    void Move()
    {
        float xDir = Random.Range(-1f, 1f);
        float yDir = Random.Range(-1f, 1f);

        currentDirection = new Vector2(xDir, yDir);

        print(currentDirection);

        rb.linearVelocity = currentDirection * speed * Time.deltaTime;
    }

    void ChangeDirection()
    {
        currentDirection *= -1;
        rb.linearVelocity = currentDirection * speed * Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        ChangeDirection();
    }
}
