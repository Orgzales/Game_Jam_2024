using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathMenuManager : MonoBehaviour
{
    public void MenuButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }
}
