using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] float speed;

    private Color color;
    private SpriteRenderer spriteRenderer;
    private new Rigidbody2D rigidbody2D;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = color;

    }

    // Update is called once per frame
    void Update()
    {
        rigidbody2D.velocity = rigidbody2D.velocity.normalized * speed;
    }

    public void ChangeColor(Color color)
    {
        this.color = color;
    }
}
