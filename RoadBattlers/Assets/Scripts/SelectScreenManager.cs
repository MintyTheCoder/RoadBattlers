using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectScreenManager : MonoBehaviour
{
    public bool playerOneSelected, playerTwoSelected = false;
    public GameObject playerSelectScreen, mapSelectScreen;
    private PlayerInputHandler inputHandler;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip buttonClick;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerOneSelected && playerTwoSelected == true)
        {
            playerSelectScreen.SetActive(false);
            mapSelectScreen.SetActive(true);
        }
    }
    public void AvocadoSelect()
    {
        StartCoroutine(Avocado());
    }

    public void DaQuanSelect()
    {
        StartCoroutine(DaQuan());
    }

    public void RobotSelect()
    {
        StartCoroutine(Robot());
    }

    public void BaseBallSelect()
    {
        StartCoroutine(BaseBall());
    }

    public void MunchSelect()
    {
        StartCoroutine(Munch());
    }

    public IEnumerator Avocado()
    {
        audioSource.PlayOneShot(buttonClick);
        playerOneSelected = true;
        inputHandler.playerOneSelectedSkin = 1;
        yield return new WaitForSeconds(1);
    }

    public IEnumerator DaQuan()
    {
        audioSource.PlayOneShot(buttonClick);
        playerOneSelected = true;
        inputHandler.playerOneSelectedSkin = 2;
        yield return new WaitForSeconds(1);
    }

    public IEnumerator Robot()
    {
        audioSource.PlayOneShot(buttonClick);
        playerOneSelected = true;
        inputHandler.playerOneSelectedSkin = 3;
        yield return new WaitForSeconds(1);
    }

    public IEnumerator BaseBall()
    {
        audioSource.PlayOneShot(buttonClick);
        playerTwoSelected = true;
        inputHandler.playerTwoSelectedSkin = 4;
        yield return new WaitForSeconds(1);
    }

    public IEnumerator Munch()
    {
        audioSource.PlayOneShot(buttonClick);
        playerTwoSelected = true;
        inputHandler.playerTwoSelectedSkin = 5;
        yield return new WaitForSeconds(1);
    }
    public IEnumerator Terrance()
    {
        audioSource.PlayOneShot(buttonClick);
        playerTwoSelected = true;
        inputHandler.playerTwoSelectedSkin = 6;
        yield return new WaitForSeconds(1);
    }
}
