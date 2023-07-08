using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject PausePanel;

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void UnPauseGame()
    {
        Time.timeScale = 1;
    }
    public void OnPauseMenu()
    {
        PausePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void UnPauseMenu()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1;
    }

}
