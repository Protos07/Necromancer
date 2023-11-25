using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject menu;
    public GameObject setting;
    public GameObject exit_panel;
    public GameObject main;
    public GameObject Dead;

    public void EnterSetting()
    {
        menu.SetActive(false);
        setting.SetActive(true);
    }
    public void ExitSetting()
    {
        setting.SetActive(false);
        menu.SetActive(true);
    }

    public void Play()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Exit()
    {
        Application.Quit();
    }
    

    public void EnterMenuInGame()
    {
        main.SetActive(false);
        menu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ExitMenuInGame()
    {
        main.SetActive(true);
        menu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void ExitInGame()
    {
        menu.SetActive(false);
        exit_panel.SetActive(true);
    }

    public void ExitInGameCancel()
    {
        menu.SetActive(true);
        exit_panel.SetActive(false);
    }

    public void ExitToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
