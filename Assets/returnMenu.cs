using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class returnMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void MenuButtonClicked()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
