using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_PauseMenu : MonoBehaviour
{
    public void OnRestartPressed()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnMenuPressed()
    {
        SceneManager.LoadScene(0);
    }

    public void OnContinuePressed()
    {
        EventManager.Instance.OnPauseGame?.Invoke(false);
    }

}
