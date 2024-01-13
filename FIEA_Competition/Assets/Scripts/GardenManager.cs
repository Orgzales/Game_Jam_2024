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
    public bool plantSelected;


    private void Awake()
    {
        instance = this;
        listTiles();
        unselectPlant();
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
        foreach (GameObject x in availablePlants)
        {
            PlantLogistics thisType = x.GetComponent<PlantLogistics>();

            if (thisType.plantType.Equals(plantType))
            {
                spawnPlant = x;
            }
        }

        foreach (GardenTile x in tiles)
        {
            x.GetComponent<Button>().interactable = true;
        }
        plantSelected = true;
    }

    public void unselectPlant()
    {
        plantSelected = false;

        foreach (GardenTile x in tiles)
        {
            x.GetComponent<Button>().interactable = false;
        }
    }

}
