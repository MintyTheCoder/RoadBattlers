using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombMoveRight : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 5.0f;

    private float rightBound = 9.5f;
    private float leftBound = -9.5f;

    private bool shot;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        //destroys and shots a object after a certain amount of time
        shot = false; 


        if (shot == false)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            StartCoroutine(DestroyAfterShot());
        }

        IEnumerator DestroyAfterShot()
        {
            shot = true;
            yield return new WaitForSeconds(1);
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
}
