using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject PausePanel;
    public GameObject EventManager;
    public void PauseGame()
    {
        EventManager.SetActive(false);
        PausePanel.SetActive(false);
        Time.timeScale = 0;
    }

    public void UnPauseGame()
    {
        Time.timeScale = 1;
    }
    public void OnPauseMenu()
    {
        EventManager.SetActive(true);
        PausePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void UnPauseMenu()
    {
        EventManager.SetActive(false);
        PausePanel.SetActive(false);
        Time.timeScale = 1;
    }

}
