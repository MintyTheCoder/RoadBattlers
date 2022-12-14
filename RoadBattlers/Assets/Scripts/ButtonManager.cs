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

    public GameObject pauseMenuUI;
    private void Start()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
    }
    public void GameStart()
    {
        //switch to next scene or level
        //currentScene++;//increase to next level number

        //allows you to delay something from happening
        StartCoroutine(ChangeToScene(currentScene));
    }

    public void GameQuit()
    {
        StartCoroutine(Quit());
    }

    public void Menu()
    {
        StartCoroutine(MainMenu());
    }

    public void ResumeGame()
    {
        StartCoroutine(Resume());
    }
    public IEnumerator ChangeToScene(int changeSceneTo)
    {
        //add for sound effect
        audioSource.PlayOneShot(buttonClick);
        //wait a few seconds before switching to the next scene
        yield return new WaitForSeconds(1);

        //load the next scene
        SceneManager.LoadScene(changeSceneTo);
    }

    public IEnumerator Quit()
    {
        //add for sound effect
        audioSource.PlayOneShot(buttonClick);
        //wait a few seconds before switching to the next scene
        yield return new WaitForSeconds(1);

        //load the next scene
        Application.Quit();
    }

    public IEnumerator MainMenu()
    {
        //add for sound effect
        audioSource.PlayOneShot(buttonClick);
        //wait a few seconds before switching to the next scene
        yield return new WaitForSeconds(1);
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
