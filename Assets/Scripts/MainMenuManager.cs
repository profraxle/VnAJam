using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [Header("Screens")]
    public GameObject[] screens; //0 main menu, 1 play menu, 2 credits screen


    public void HandleScreens(int index)
    {
        foreach (GameObject screen in screens)
        {
            screen.SetActive(false);
        }
        screens[index].SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void PlayGame(int index)
    {
        SceneManager.LoadScene(index);
    }
}
