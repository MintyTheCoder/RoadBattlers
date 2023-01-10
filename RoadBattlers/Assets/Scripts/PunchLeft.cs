using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchLeft : MonoBehaviour
{
    //PlayerMovement playerMovement;
    Vector2 spawnPos;
    Vector2 currentPos;
    Transform transformParent;

    private float rightBound = 9.5f;
    private float leftBound = -9.5f;

    int speed = 4;
    // Start is called before the first frame update
    void Start()
    {
        //transformParent = GetComponentInParent<Transform>();
        spawnPos = gameObject.transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        currentPos = gameObject.transform.position;

        transform.Translate(Vector2.left * speed * Time.deltaTime);

        if (currentPos.x < spawnPos.x -1)
        {
            Debug.Log(spawnPos);
            Debug.Log("Hoarray!");
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
