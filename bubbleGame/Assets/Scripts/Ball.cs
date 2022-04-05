using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] CircleCollider2D CircleCollider;
    public bool fromKnob;

    public Color color;
    private SpriteRenderer spriteRenderer;
    private new Rigidbody2D rigidbody2D;
    public List<Ball> neighbours=new List<Ball>();
    public bool collided=false;


    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        Paint();
        neighbours.Clear();
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
            Ball otherBall = collision.gameObject.GetComponent<Ball>();
            if (fromKnob)
            {
                if (color == otherBall.color)
                {
                    Destroy(gameObject);
                    otherBall.Explode();
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Collider"))
        {
            collision.transform.parent.GetComponent<Ball>().neighbours.Add(this);
        }
    }

    private void Explode()
    {
        collided = true;
        for (int i = 0; i < neighbours.Count; i++)
        {
            if (!neighbours[i].collided && neighbours[i]!=null)
            {
                if (color == neighbours[i].color)
                {
                    neighbours[i].Explode();
                }
            }
        }
        Destroy(gameObject);
    }
}

