using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//needed to switch scenes in Unity
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private int currentScene;
    //added for sounds
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip buttonClick;

    PlayerInputHandler playerInputHandler;

    public GameObject pauseMenuUI;

    private void Start()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
    }

    public void SelectScreens()
    {
        //switch to next scene or level
        //currentScene++;//increase to next level number

        StartCoroutine(SelectScreen());
    }

    public void GameQuit()
    {
        StartCoroutine(Quit());
    }

    public void Menu()
    {
        StartCoroutine(MainMenu());
    }

    public IEnumerator SelectScreen()
    {
        //add for sound effect
        audioSource.PlayOneShot(buttonClick);
        //wait a few seconds before switching to the next scene
        yield return new WaitForSeconds(.5f);
        Debug.Log("Start Button Pressed");
        //load the next scene
        SceneManager.LoadScene("Select Screens");
        
    }

    public IEnumerator Quit()
    {
        //add for sound effect
        audioSource.PlayOneShot(buttonClick);
        //wait a few seconds before switching to the next scene
        yield return new WaitForSeconds(.5f);

        //load the next scene
        Application.Quit();
    }

    public IEnumerator MainMenu()
    {
        //add for sound effect
        audioSource.PlayOneShot(buttonClick);
        //wait a few seconds before switching to the next scene
        yield return new WaitForSeconds(.5f);
        SceneManager.LoadScene("Main Menu");
        
    }

    public IEnumerator Resume()
    {
        //add for sound effect
        audioSource.PlayOneShot(buttonClick);

        pauseMenuUI.SetActive(false);

        Time.timeScale = 1;
        yield return true;
    }
}
