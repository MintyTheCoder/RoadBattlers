using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMoveLeft : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 5.0f;

    private float rightBound = 9.5f;
    private float leftBound = -9.5f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);


        if (transform.position.x > rightBound)
        {
            Destroy(gameObject);
        }

        else if (transform.position.x < leftBound)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player 1" || collision.tag == "Player 2")
        {
            Destroy(gameObject);
        }
    }
}