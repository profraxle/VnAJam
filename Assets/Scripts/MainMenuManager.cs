using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [Header("Screens")]
    public GameObject[] screens; //0 main menu, 1 play menu, 2 credits screen

    [Header("Depressed Image")]
    public Sprite depressedImage;

    public void HandleScreens(int index)
    {
        GameObject button = EventSystem.current.currentSelectedGameObject;
        Image buttonImage = button.GetComponent<Button>().targetGraphic as Image;
        Sprite sprite = buttonImage.sprite;
        buttonImage.sprite = depressedImage;

        StartCoroutine(HandleScreensCor(index, buttonImage, sprite));
    }

    public void QuitGame()
    {
        GameObject button = EventSystem.current.currentSelectedGameObject;
        Image buttonImage = button.GetComponent<Button>().targetGraphic as Image;
        Sprite sprite = buttonImage.sprite;
        buttonImage.sprite = depressedImage;

        StartCoroutine(QuitCor());
    }

    public void PlayGame(int index)
    {
        GameObject button = EventSystem.current.currentSelectedGameObject;
        Image buttonImage = button.GetComponent<Button>().targetGraphic as Image;
        Sprite sprite = buttonImage.sprite;
        buttonImage.sprite = depressedImage;

        StartCoroutine(PlayGameCor(index, buttonImage, sprite));
    }

    IEnumerator PlayGameCor(int index, Image buttonImage, Sprite orgSprite)
    {
        yield return new WaitForSeconds(.3f);
        buttonImage.sprite = orgSprite;

        SceneManager.LoadScene(index);

    }

    IEnumerator HandleScreensCor(int index, Image buttonImage, Sprite orgSprite)
    {
        yield return new WaitForSeconds(.3f);
        buttonImage.sprite = orgSprite;

        foreach (GameObject screen in screens)
        {
            screen.SetActive(false);
        }
        screens[index].SetActive(true);
    }

    IEnumerator QuitCor()
    {
        yield return new WaitForSeconds(.3f);
        Application.Quit();
    }
}
