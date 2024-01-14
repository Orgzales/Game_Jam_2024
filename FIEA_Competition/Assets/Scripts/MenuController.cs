using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{

    public GameObject MainMenu;
    public GameObject SettingsMenu;
    public GameObject InfoMenu;

    void Start()
    {
        BackButton();
    }

    public void InfoButton()
    {
        MainMenu.SetActive(false);
        InfoMenu.SetActive(true);
    }

    public void PlayButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
    }

    public void SettingButton()
    {
        MainMenu.SetActive(false);
        SettingsMenu.SetActive(true);
    }

    public void BackButton()
    {
        MainMenu.SetActive(true);
        SettingsMenu.SetActive(false);
        InfoMenu.SetActive(false);

    }

    public void ExitButton()
    {
        Application.Quit();
    }

}
