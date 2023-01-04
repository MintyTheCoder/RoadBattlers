using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchRight : MonoBehaviour
{
    PlayerMovement playerMovement;
    Vector2 playerPos;
    Vector2 punchPos;

    int speed = 4;
    // Start is called before the first frame update
    void Start()
    {
        playerPos.x = playerMovement.playerPos.x;
        punchPos = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        if (punchPos.x > playerPos.x +1)
        {
            Destroy(gameObject);
        }
    }
}
