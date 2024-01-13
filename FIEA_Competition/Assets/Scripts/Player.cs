using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Declaration")]
    Inventory inventory;
    public float plantHealth = 100f;
    public float hunger = 100f;

    [Header("Sustaining Factor Check")]
    public bool ate = false;
    public bool fedPlant = false;

    public void sleep()
    {
        // plant actions

        // make more complex?
        if (!ate)
        {
            hunger -= 20;
        }

        if (!survived())
        {
            // die
        }
        fedPlant = false;
        ate = false;
    }

    public void feedYourPlant()
    {
        if (inventory.getSunJars() >= 1)
        {
            // add multiplier for how much the plant eats
            inventory.useSun(1);
            if (plantHealth < 100)
            {
                plantHealth += 5;
                if (plantHealth > 100)
                {
                    plantHealth = 100;
                }
            }
            fedPlant = true;
        }
    }

    public void eat()
    {
        // remove crop, increase hunger if hunger < 100
        ate = true;
    }


    public bool survived()
    {
        if (hunger <= 0)
        {
            return false;
        }
        else if (plantHealth <= 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
