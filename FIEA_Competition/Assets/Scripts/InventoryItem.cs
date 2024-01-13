using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class InventoryItem : MonoBehaviour
{

    public string displayName;
    public string displayDesc;

    [Header("Visual Aspects")]
    public TextMeshProUGUI name;
    public TextMeshProUGUI description;
    public TextMeshProUGUI quantity;
    public Image icon;
    public PlantType plantType;
    public bool isPlant;

    private void Start()
    {
        name.text = displayName;
        description.text = displayDesc;
    }

    private void Update()
    {
        if (Inventory.instance.isOpen)
        {

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
