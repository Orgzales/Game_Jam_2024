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
    public Button thisButton;

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
    public static bool sunSeleced;

    private void Start()
    {
        if (!isSun)
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

                        if (inventory.seeds[key] < 1)
                        {
                            thisButton.interactable = false;
                        }
                        else
                        {
                            thisButton.interactable = true;
                        }
                    }

                }

            }
            else if (isSun)
            {
                quantity.text = Inventory.instance.sunJars.ToString();
            }
            else //IS CROP!@!!
            {
                foreach (var key in inventory.crops.Keys)
                {
                    if (key.name.Equals(nameGetter))
                    {
                        quantity.text = inventory.crops[key].ToString();

                        if (inventory.crops[key] < 1)
                        {
                            thisButton.interactable = false;
                        }
                        else if (!Player.instance.ate)
                        {
                            thisButton.interactable = true;
                        }
                    }

                }

                thisButton.interactable = !Player.instance.ate;
            }
            
        }
    }

    public void selectSeed()
    {
        GardenManager.instance.choosePlant(plantType);
        Debug.Log(plantType);

        if (sunSeleced)
        {
            sunSeleced = false;
        }
    }

    public void selectConsumable()
    {
        GardenManager.instance.unselectPlant();
        if (!isSun)
        {
            CropItem crop;
            foreach (CropItem x in GameManager.instance.worldCrops)
            {
                if (x.name == plantType.ToString())
                {
                    crop = x;
                    Player.instance.eat(crop);
                    break;
                }
            }
        }
        else
        {
            sunSeleced = !sunSeleced;

            PlayerPlant.instance.openMenu(sunSeleced);


            foreach (GardenTile x in GardenManager.instance.tiles)
            {
                if (sunSeleced)
                {
                    x.chooseMenuItem(3);
                }
                else
                {
                    x.clearMenu();
                }
                
            }
            
        }



    }
}
