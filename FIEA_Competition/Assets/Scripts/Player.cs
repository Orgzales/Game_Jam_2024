using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Declaration")]
    Inventory inventory;
    public static Player instance;
    public float plantHealth = 100f;
    public float hunger = 100f;

    [Header("Sustaining Factor Check")]
    public bool ate = false;
    public bool fedPlant = false;

    public void sleep()
    {

        if (!ate)
        {
            hunger -= 50;
        }

        if(!fedPlant)
        {
            plantHealth -= 50;
        }

        if (!survived())
        {
            // die
        }
        fedPlant = false;
        ate = false;
    }

    public void harvest(PlantLogistics plant){
        if(plant.isGrown()){
            for(int i = 0; i < GameManager.instance.getWorldCrops().Count; i++){
                if(plant.getPlantType().ToString() == GameManager.instance.getWorldCrops()[i].getName()){
                    Inventory.instance.addCrop(GameManager.instance.getWorldCrops()[i], 1);
                    break;
                }
            }
        }
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

    public void eat(CropItem food)
    {
        // remove crop, increase hunger if hunger < 100
        if(Inventory.instance.getCropInventory().ContainsKey(food) && Inventory.instance.getCropInventory()[food] >= 1 && ate == false){
            Inventory.instance.useFood(food);
            hunger += food.getSaturation();
            ate = true;
        } else if(ate == true){
            Debug.Log("Player already ate today");
        }
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
