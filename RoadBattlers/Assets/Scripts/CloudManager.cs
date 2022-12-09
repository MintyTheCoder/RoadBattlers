using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudManager : MonoBehaviour
{
    public GameObject smallCloud;
    public GameObject bigCloud;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("CloudSpawn");
    }

    public IEnumerator CloudSpawn()
    {
        AddClouds();        
        yield return new WaitForSeconds(2.5f);
        StartCoroutine("CloudSpawn");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddClouds()
    {
        Vector2 cloudPointOne = new Vector2(-4.0f, 0.8f);
        Vector2 cloudPointTwo = new Vector2(-4.5f, 1.5f);
        Instantiate(smallCloud, cloudPointOne, Quaternion.identity);
        Instantiate(bigCloud, cloudPointTwo, Quaternion.identity);
    }
}
