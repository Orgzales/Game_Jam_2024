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

    public GameObject[] HealthBar = new GameObject[5];
    public GameObject[] FoodBar = new GameObject[5];



    private void Awake()
    {
        instance = this;
    }

    void Update()
    {
        checkHP();
        checkFood();
    }

    public void sleep()
    {

        if (!ate)
        {
            hunger -= 50;
        }

        if (!fedPlant)
        {
            plantHealth -= 50;
        }

        if (!survived())
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("DeathScene");
        }
        fedPlant = false;
        ate = false;
    }
    //hi
    public void harvest(PlantLogistics plant)
    {
        for (int i = 0; i < GameManager.instance.getWorldCrops().Count; i++)
        {
            Debug.Log("pre condition 2");
            if (plant.getPlantType().ToString() == GameManager.instance.getWorldCrops()[i].getName())
            {
                Debug.Log("if worked");
                Inventory.instance.addCrop(GameManager.instance.getWorldCrops()[i], 2);
                plant.transform.parent.GetComponent<GardenTile>().destroyPlant();
                break;
            }
            else
            {
                Debug.Log("if didnt work");
            }
        }
    }
        public void feedPlant(PlantLogistics plant){
        if (Inventory.instance.getSunJars() >= 1 && plant.GotSun == false)
        {
            plant.GotSun = true;
            Inventory.instance.purchased(1);
        }
    }

    public void checkHP()
    {
        if (plantHealth <= 90)
            HealthBar[4].SetActive(false);
        else
            HealthBar[4].SetActive(true);
        if (plantHealth <= 70)
            HealthBar[3].SetActive(false);
        else
            HealthBar[3].SetActive(true);
        if (plantHealth <= 50)
            HealthBar[2].SetActive(false);
        else
            HealthBar[2].SetActive(true);
        if (plantHealth <= 30)
            HealthBar[1].SetActive(false);
        else
            HealthBar[1].SetActive(true);
        if (plantHealth <= 0)
            HealthBar[0].SetActive(false);
    }
    public void checkFood()
    {
        if (hunger <= 90)
            FoodBar[4].SetActive(false);
        else
            FoodBar[4].SetActive(true);
        if (hunger <= 70)
            FoodBar[3].SetActive(false);
        else
            FoodBar[3].SetActive(true);
        if (hunger <= 50)
            FoodBar[2].SetActive(false);
        else
            FoodBar[2].SetActive(true);
        if (hunger <= 30)
            FoodBar[1].SetActive(false);
        else
            FoodBar[1].SetActive(true);
        if (hunger <= 0)
            FoodBar[0].SetActive(false);
    }

    public void feedYourPlant()
    {
        if (Inventory.instance.getSunJars() >= 1 && fedPlant == false)
        {
            // add multiplier for how much the plant eats
            Inventory.instance.useSun(1);
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
        if (Inventory.instance.getCropInventory().ContainsKey(food) && Inventory.instance.getCropInventory()[food] >= 1 && ate == false)
        {
            Inventory.instance.useFood(food);
            hunger += food.getSaturation();
            ate = true;
        }
        else if (ate == true)
        {
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
