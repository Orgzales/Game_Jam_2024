using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlant : MonoBehaviour
{
    public GameObject plantMenu;
    public static PlayerPlant instance;

    private void Start()
    {
        instance = this;
    }

    public void openMenu(bool state)
    {
        if (!Player.instance.fedPlant)
        {
            plantMenu.SetActive(state);
        }
        else
        {
            plantMenu.SetActive(false);
        }
       
    }

    public void feedPlant()
    {
        Player.instance.feedYourPlant();
        plantMenu.SetActive(false);
    }
}
