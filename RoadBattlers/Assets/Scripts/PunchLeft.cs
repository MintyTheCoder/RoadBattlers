using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchLeft : MonoBehaviour
{
    //PlayerMovement playerMovement;
    Vector2 playerPos;
    Vector2 punchPos;
    Transform transformParent;

    private float rightBound = 9.5f;
    private float leftBound = -9.5f;

    int speed = 4;
    // Start is called before the first frame update
    void Start()
    {
        transformParent = GetComponentInParent<Transform>();
        playerPos = transformParent.position;
        punchPos = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        if (punchPos.x < playerPos.x -1)
        {
            Destroy(gameObject);
        }

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
