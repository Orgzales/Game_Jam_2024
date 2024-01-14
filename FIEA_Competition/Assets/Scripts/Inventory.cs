using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    public bool isOpen;

    public int sunJars = 5;
    public Dictionary<SeedItem, int> seeds = new Dictionary<SeedItem, int>();
    public Dictionary<CropItem, int> crops = new Dictionary<CropItem, int>();

    public GameObject[] inventoryDisplay;
    public GameObject inventoryMenu;

    private void Awake()
    {
        instance = this;
        
    }

    private void Start()
    {
        addSeed(GameManager.instance.mushroom, 1);
        addSeed(GameManager.instance.kale, 1);
        addSeed(GameManager.instance.apple, 0);
        addSeed(GameManager.instance.potato, 0);

        addCrop(GameManager.instance.mushroomPlant, 6);
        addCrop(GameManager.instance.kalePlant, 2);
        addCrop(GameManager.instance.applePlant, 0);
        addCrop(GameManager.instance.potatoPlant, 0);
    }

    public void toggleInventory()
    {
       isOpen = !isOpen;
        inventoryMenu.SetActive(isOpen);
        GardenManager.instance.unselectPlant();
        InventoryItem.sunSeleced = false;

        displayInventory();
    }

    public void displayInventory()
    {
        foreach (GameObject x in inventoryDisplay)
        {
            InventoryItem inventory = x.GetComponent<InventoryItem>();

           if (inventory.isPlant)
            {
              foreach (var key in seeds.Keys)
                {
                    if (key.name.Equals(inventory.plantType.ToString()))
                    {
                        x.SetActive(true);
                    }
                   
                }
            }
        }
    }

    public int getSunJars()
    {
        return sunJars;
    }
    public void useSun(int sun)
    {
        sunJars -= sun;
    }
    public void purchased(int price)
    {
        sunJars -= price;
    }

    public void sold(int price)
    {
        sunJars += price;
    }
    public Dictionary<SeedItem, int> getSeedIventory()
    {
        return seeds;
    }

    
    public SeedItem getSeedByType(PlantType type){
        foreach(KeyValuePair<SeedItem, int> entry in seeds){
            if(entry.Key.getPlantType() == type){
                return entry.Key;
            }
        }
        return null;
    }
    public void addSeed(SeedItem seed, int num)
    {
        if (!seeds.ContainsKey(seed))
        {
            seeds.Add(seed, num);
        }
        else
        {
            seeds[seed]+= num;
        }

    }

    public void useSeed(SeedItem seed){
        seeds[seed]--;
    }
    public Dictionary<CropItem, int> getCropInventory()
    {
        return crops;
    }
    public void addCrop(CropItem crop, int num)
    {
        if(!crops.ContainsKey(crop)){
            crops.Add(crop, num);
        }
        else{
            crops[crop] += num;
        }
    }

    public void useFood(CropItem food){
        if(crops.ContainsKey(food) && crops[food] >= 1){
            crops[food]--;
        }
    }
}
