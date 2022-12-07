using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudManager : MonoBehaviour
{
    public GameObject SmallCloud;
    public GameObject BigCloud;

    Vector2 cloudPointOne = new Vector2(-2.5f, 1.5f);
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(BigCloud, cloudPointOne, Quaternion.identity);
        
    }

    public IEnumerator CloudSpawn()
    { 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
