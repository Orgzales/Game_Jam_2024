using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GardenManager : MonoBehaviour
{
    public static GardenManager instance;
   public List<GardenTile> tiles = new List<GardenTile>();
   public Transform tileParent;

    public GameObject[] availablePlants;
    public GameObject spawnPlant;

    public PlantType lastPlant;
    public bool plantSelected;
    public GardenTile currentTile;

    private bool choosingToggle;

    private void Awake()
    {
        instance = this;
        listTiles();
        unselectPlant();
    }

    public void setCurrentTile(GardenTile tile){
        currentTile = tile;
    }
    private void listTiles()
    {
        foreach (Transform child in tileParent)
        {
            tiles.Add(child.GetComponent<GardenTile>());
        }
    }

    public void choosePlant(PlantType plantType)
    {
        if (plantType.Equals(lastPlant) && !choosingToggle)
        {
            unselectPlant();
            choosingToggle = true;
        }
        else
        {
            choosingToggle = false;
            foreach (GameObject x in availablePlants)
            {
                PlantLogistics thisType = x.GetComponent<PlantLogistics>();

                if (thisType.plantType.Equals(plantType))
                {
                    spawnPlant = x;
                }
            }

            plantSelected = true;
            lastPlant = plantType;

            foreach (GardenTile x in tiles)
            {
                x.plantCheckin();
                x.chooseMenuItem(0);
            }
        }
       
        
    }

    public void unselectPlant()
    {
        foreach (GardenTile x in tiles)
        {
            x.clearMenu();
        }
        plantSelected = false;
    }

}
