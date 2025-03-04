using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class returnMenu : MonoBehaviour
{
    [Header("Depressed Button")]
    public Sprite depressedButton;

    // Start is called before the first frame update
    public void MenuButtonClicked()
    {
        GameObject button = EventSystem.current.currentSelectedGameObject;
        Image buttonImage = button.GetComponent<Button>().targetGraphic as Image;
        Sprite sprite = buttonImage.sprite;
        buttonImage.sprite = depressedButton;

        StartCoroutine(LoadMainMenu());
    }

    IEnumerator LoadMainMenu()
    {
        yield return new WaitForSeconds(.3f);

        SceneManager.LoadScene(0);
    }
}
