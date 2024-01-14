using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GardenTile : MonoBehaviour
{
    private Inventory inventory;
    [HideInInspector] public GameObject plant;
    [HideInInspector] public GameObject plantPreview;
    private GardenManager manager;

    public GameObject plantMenu;
    public SeedItem thisSeed;
    public PlantType conserved;

    public GameObject[] menuItems;
    public bool isHarvest;

    private void Start()
    {
        inventory = Inventory.instance;
        manager = GardenManager.instance;
    }

    public void conservePlant(PlantType plant) {
        conserved = plant;
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

    public void destroyPlant()
    {
        Destroy(plant);
    }

    public void chooseMenuItem(int num) //Harvest = 2, Feed = 3, Plant = 0
    {
        clearMenu();
        plantCheckin();

       
        menuItems[num].SetActive(true);

        if (num.Equals(3))
        {
            if (plant)
            {
                if (plant.GetComponent<PlantLogistics>().GotSun)
                {
                    menuItems[num].SetActive(false);
                }
            }
            
        }

        if (isHarvest)
        {
            menuItems[2].SetActive(true);
        }
    }

    public void clearMenu()
    {
        foreach (GameObject x in menuItems)
        {
            x.SetActive(false);
        }

        if (isHarvest)
        {
            menuItems[2].SetActive(true);
        }
    }

    public void placePlant() //this is what is called when the tile is clicked
    {
        // GardenManager.instance.setCurrentTile(this);
       
       // plantCheckin();
    }

    public void plantCheckin()
    {
        plantMenu.SetActive(true);
       
    }

    public void replacePlant()
    {
        if (manager.plantSelected)
        {
            if (plant != null)
            {
                if (manager.spawnPlant.Equals(plant))
                {
                    return;
                }

                Destroy(plant);
            }

            // if the player has the seed and the player has at least one
            if (Inventory.instance.getSeedIventory().ContainsKey(Inventory.instance.getSeedByType(GardenManager.instance.lastPlant))
            && Inventory.instance.getSeedIventory()[Inventory.instance.getSeedByType(GardenManager.instance.lastPlant)] >= 1)
            {
                Inventory.instance.useSeed(Inventory.instance.getSeedByType(GardenManager.instance.lastPlant));
                createPlant();
            } else {
                Debug.Log("false");
            }
        }
    }

    private void createPlant()
    {
        plant = Instantiate(manager.spawnPlant, transform.position, Quaternion.identity);
        plant.transform.parent = this.transform;
        Destroy(plantPreview);
    }

    public void feedPlant()
    {
        PlantLogistics thisPlant = plant.GetComponent<PlantLogistics>();

        Player.instance.feedPlant(thisPlant);
        menuItems[3].SetActive(false);
    }

    public void waterPlant()
    {
        PlantLogistics thisPlant = plant.GetComponent<PlantLogistics>();


    }

    public void harvestPlant()
    {
        PlantLogistics thisPlant = plant.GetComponent<PlantLogistics>();
        isHarvest = false;

        Player.instance.harvest(thisPlant);
        menuItems[2].SetActive(false);
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
