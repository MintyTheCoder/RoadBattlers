using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//needed to switch scenes in Unity
using UnityEngine.SceneManagement;

public class WinnerUIManager : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip buttonClick;
    public void Menu()
    {
        StartCoroutine(MainMenu());
    }
    
    public void Again()
    {
        StartCoroutine(PlayAgain());
    }
    public IEnumerator MainMenu()
    {
        //add for sound effect
        audioSource.PlayOneShot(buttonClick);
        Time.timeScale = 1;
        //wait a few seconds before switching to the next scene
        yield return new WaitForSeconds(.5f);
        SceneManager.LoadScene("Main Menu");

    }

    public IEnumerator PlayAgain()
    {
        //add for sound effect
        audioSource.PlayOneShot(buttonClick);
        Time.timeScale = 1;
        //wait a few seconds before switching to the next scene
        yield return new WaitForSeconds(.5f);
        SceneManager.LoadScene("Select Screens");
    }
}
