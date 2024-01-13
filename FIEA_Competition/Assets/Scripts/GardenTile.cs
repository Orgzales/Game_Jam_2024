using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GardenTile : MonoBehaviour
{
    private Inventory inventory;
    [HideInInspector]public GameObject plant;
    [HideInInspector]public GameObject plantPreview;
    private GardenManager manager;

    public GameObject plantMenu;

    private void Start()
    {
        inventory = Inventory.instance;
        manager = GardenManager.instance;
    }

    public void previewPlant()
    {
        if (checkPlantStatus())
        {
            plantPreview = Instantiate(manager.spawnPlant, transform.position, Quaternion.identity);
            plantPreview.transform.parent = this.transform;
        }
    }

    public void unpreviewPlant()
    {
        if (checkPlantStatus())
        {
            Destroy(plantPreview);
        }
    }

    public void placePlant() //this is what is called when the tile is clicked
    {
       if (plant == null)
        {
            if (inventory.getSunJars() >= 0)
            {
                createPlant(1);
            }
        }
            
        plantCheckin();
    }

    private void plantCheckin()
    {
        plantMenu.SetActive(true);
    }

    public void replacePlant()
    {
        if (inventory.getSunJars() >= 0)
        {
            Destroy(plant);
            createPlant(1);
        }
    }

    private void createPlant(int cost)
    {
        inventory.useSun(cost);
        plant = Instantiate(manager.spawnPlant, transform.position, Quaternion.identity);
        plant.transform.parent = this.transform;
        Destroy(plantPreview);
    }

    public void feedPlant()
    {
        PlantLogistics thisPlant = plant.GetComponent<PlantLogistics>();


    }

    public void waterPlant()
    {
        PlantLogistics thisPlant = plant.GetComponent<PlantLogistics>();


    }

    public void harvestPlant()
    {
        PlantLogistics thisPlant = plant.GetComponent<PlantLogistics>();


    }


    private bool checkPlantStatus()
    {
        if (plant == null && manager.plantSelected)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
