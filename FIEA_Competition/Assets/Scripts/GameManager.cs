using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Declaration")]
    public int round = 0;
    public List<SeedItem> worldSeeds = new List<SeedItem>();
    public SeedItem kale;
    public SeedItem mushroom;
    public SeedItem apple;
    public static GameManager instance;

    //(PlantHP, HPlostPerRound, GrowthPerRound, FoodQuality, SunGrowthBoost, SunJarWorth,  BarterPlus, SunJarNeeded, MaxGrowth, Description)
    //public PlantItem Mushroom = new PlantItem(10f, 5f, 10f, 5f, 0f, 10f, 0, 0, 10f, "Mushrooms need no SUNLIGHT to grow, they love the dark so they are quite common to the market.");
    //public PlantItem Kale = new PlantItem(20f, 5f, 5f, 10f, 10f, 20f, 1, 1, 15f, "Kale needs very little SUN to grow, but still requires it to finish blooming.");
    //public PlantItem Fruit = new PlantItem(20f, 10f, 1f, 20f, 10f, 40f, 3, 2, 30f, "Fruit is a rich crop that needs constant SUNLIGHT, which makes it higher in demand of the market.");
    public List<SeedItem> getWorldSeeds(){
        return worldSeeds;
    }
    private void Awake()
    {
        instance = this; 
        mushroom = new SeedItem(PlantType.mushroom, 10);
        kale = new SeedItem(PlantType.kale, 50);
        apple = new SeedItem(PlantType.fruit, 100);
        worldSeeds.Add(mushroom);
        worldSeeds.Add(kale);
        worldSeeds.Add(apple);


        Inventory.instance.addSeed(mushroom, 10);
        Inventory.instance.addSeed(kale, 50);
        Inventory.instance.addSeed(apple, 100);

        // worldSeeds = {mushroom, kale, apple};
    }


    public void NextRound()
    {
        round++;

        //call any seperate script from here

    }

}
