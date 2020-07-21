using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_MainMenu : MonoBehaviour
{
    public void OnFeedThemPressed()
    {
        SceneManager.LoadScene(1);
    }

    public void OnFetchPressed()
    {
        SceneManager.LoadScene(2);
    }

}
