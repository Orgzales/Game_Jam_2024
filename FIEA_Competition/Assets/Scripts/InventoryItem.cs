using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class InventoryItem : MonoBehaviour
{
    [Header("Grab")]
    public string nameGetter;
    public string displayDesc;
    private Inventory inventory;

    [Header("Visual Aspects")]
    public TextMeshProUGUI name;
    public TextMeshProUGUI description;
    public TextMeshProUGUI quantity;
    public Image icon;

    [Header("Plant Stuff")]
    public PlantType plantType;
    public bool isPlant;

    [Header("Sun Jar")]
    public bool isSun;


    private void Start()
    {
        if (isPlant)
        {
            nameGetter = plantType.ToString();
        }
        
        inventory = Inventory.instance;
        name.text = nameGetter;
        description.text = displayDesc;
        
    }

    private void Update()
    {
        if (Inventory.instance.isOpen)
        {
            if (isPlant)
            {
                foreach (var key in inventory.seeds.Keys)
                {
                    if (key.name.Equals(nameGetter))
                    {
                        quantity.text = inventory.seeds[key].ToString();
                    }

                }

            }
            else if (isSun)
            {
                quantity.text = Inventory.instance.sunJars.ToString();
            }
            
        }
    }

    public void selectSeed()
    {
        GardenManager.instance.choosePlant(plantType);
    }

    public void selectConsumable()
    {

    }
}
