using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//needed to switch scenes in Unity
using UnityEngine.SceneManagement;

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
        //playerSelectScreen.SetActive(true);
        //mapSelectScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {   
        if (playerOneSelected && playerTwoSelected == true)
        {
            playerSelectScreen.SetActive(false);
            mapSelectScreen.SetActive(true);
        }

        else    
        {
            return;
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

    public void TerranceSelect()
    {
        StartCoroutine(Terrance());
    }

    public void SkyCitySelect()
    {
        StartCoroutine(SkyCity());
    }

    public void BluIslandSelect()
    {
        StartCoroutine(BluIsland());
    }

    public IEnumerator Avocado()
    {
        audioSource.PlayOneShot(buttonClick);
        //yield return new WaitForSeconds(0.5f);
        playerOneSelected = true;
        Debug.Log("Avocado Selected");
        //  qyield return new WaitForSeconds(0.5f);
        PlayerPrefs.SetInt("player1SkinNumber", 0);
        yield return new WaitForSeconds(1);
    }

    public IEnumerator DaQuan()
    {
        audioSource.PlayOneShot(buttonClick);
        //yield return new WaitForSeconds(0.5f);
        playerOneSelected = true;
        Debug.Log("DaQuan Selected");
        //yield return new WaitForSeconds(0.5f);
        PlayerPrefs.SetInt("player1SkinNumber", 1);
        yield return new WaitForSeconds(1);
    }

    public IEnumerator Robot()
    {
        audioSource.PlayOneShot(buttonClick);
        //yield return new WaitForSeconds(0.5f);
        playerOneSelected = true;
        Debug.Log("Robot Selected");
        //yield return new WaitForSeconds(0.5f);
        PlayerPrefs.SetInt("player1SkinNumber", 2);
        yield return new WaitForSeconds(1);
    }

    public IEnumerator BaseBall()
    {
        audioSource.PlayOneShot(buttonClick);
        //yield return new WaitForSeconds(0.5f);
        playerTwoSelected = true;
        Debug.Log("Baseball Selected");
        //yield return new WaitForSeconds(0.5f);
        PlayerPrefs.SetInt("player2SkinNumber", 0);
        yield return new WaitForSeconds(1);
    }

    public IEnumerator Munch()
    {
        audioSource.PlayOneShot(buttonClick);
        //yield return new WaitForSeconds(0.5f);
        playerTwoSelected = true;
        Debug.Log("Munch Selected");
        //yield return new WaitForSeconds(0.5f);
        PlayerPrefs.SetInt("player2SkinNumber", 1);
        yield return new WaitForSeconds(1);
    }
    public IEnumerator Terrance()
    {
        audioSource.PlayOneShot(buttonClick);
        //yield return new WaitForSeconds(0.5f);
        playerTwoSelected = true;
        Debug.Log("Terrance Selected");
        //yield return new WaitForSeconds(0.5f);
        PlayerPrefs.SetInt("player2SkinNumber", 2);
        yield return new WaitForSeconds(1);
    }

    public IEnumerator SkyCity()
    {
        audioSource.PlayOneShot(buttonClick);
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Sky City");
    }

    public IEnumerator BluIsland()
    {
        audioSource.PlayOneShot(buttonClick);
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Blu Island");
    }
}
