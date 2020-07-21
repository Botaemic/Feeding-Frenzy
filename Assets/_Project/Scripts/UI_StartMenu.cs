using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_StartMenu : MonoBehaviour
{
    public void OnStartPressed()
    {
        EventManager.Instance.OnStartGame?.Invoke();
    }

    public void OnMenuPressed()
    {
        SceneManager.LoadScene(0);
    }
}
