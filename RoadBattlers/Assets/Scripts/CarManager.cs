using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarManager : MonoBehaviour
{
    public GameObject[] cars;
    private int carNumber;

    Vector2 spawnPlace = new Vector2(10, -4.25f);

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CarSpawn(carNumber));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator CarSpawn(int carNumber)
    {
        carNumber = Random.Range(0, 7);
        Instantiate(cars[carNumber], spawnPlace, Quaternion.identity);
        //wait a few seconds before switching to the next scene
        yield return new WaitForSeconds(2);
        StartCoroutine(CarSpawn(carNumber));
    }
}
