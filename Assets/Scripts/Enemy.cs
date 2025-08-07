using UnityEngine;

public class Enemy : MonoBehaviour
{

    public Player player;

    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        Vector2 test = new(player.transform.position.x + 1f, player.transform.position.y);
        transform.Translate(test);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    private readonly float speed = 4f;
    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 playerPosition = new(player.transform.position.x, player.transform.position.y + 1);

        Vector2 next = Vector2.MoveTowards(rb.position, playerPosition, speed * Time.fixedDeltaTime);
        rb.MovePosition(next);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision);
    }
}
