using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//needed to switch scenes in Unity
using UnityEngine.SceneManagement;
public class MainMenuManager : MonoBehaviour
{
    [SerializeField] int currentScene;

    //added for sounds
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip buttonClick;
    private void Start()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
    }
    public void GameStart()
    {
        //switch to next scene or level
        currentScene++;//increase to next level number

        //allows you to delay something from happening
        StartCoroutine(ChangeToScene(currentScene));
    }

    public void GameQuit()
    {
        StartCoroutine(Quit());
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
}
