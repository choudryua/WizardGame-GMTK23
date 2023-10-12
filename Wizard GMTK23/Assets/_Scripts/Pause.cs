using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

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

    private EventSystem[] eventSystems;
    public void OnPauseMenu()
    {
        eventSystems = FindObjectsOfType<EventSystem>();
        foreach (var manager in eventSystems)
        {
            var test = manager.gameObject;
            test.SetActive(false);
        }
        EventManager.SetActive(true);
        PausePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void UnPauseMenu()
    {
        foreach (var manager in eventSystems)
        {
            var test = manager.gameObject;
            test.SetActive(true);
        }
        EventManager.SetActive(false);
        PausePanel.SetActive(false);
        Time.timeScale = 1;
    }

}
