using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] float speed;
    public bool fromKnob;

    public Color color;
    private SpriteRenderer spriteRenderer;
    private new Rigidbody2D rigidbody2D;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        Paint();
    }
    // Update is called once per frame
    void Update()
    {
        Paint();
        rigidbody2D.velocity = rigidbody2D.velocity.normalized * speed;
    }

    public void SetColor(Color color)
    {
        this.color = color;
    }
    public void Paint()
    {
        spriteRenderer.color = color;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            speed = 0;
            if (fromKnob)
            {
                fromKnob = false;
                Ball otherBall = collision.gameObject.GetComponent<Ball>();
                if (color == otherBall.color)
                {
                    Destroy(otherBall.gameObject);
                    Destroy(gameObject);
                }
            }
        }
    }
}

