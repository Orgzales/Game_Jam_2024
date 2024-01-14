using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Declaration")]
    public int round = 0;
    public List<SeedItem> worldSeeds = new List<SeedItem>();
    public List<CropItem> worldCrops = new List<CropItem>();
    public SeedItem kale;
    public SeedItem mushroom;
    public SeedItem apple;
    public SeedItem potato;
    public CropItem kalePlant;
    public CropItem mushroomPlant;
    public CropItem applePlant;
    public CropItem potatoPlant;
    public static GameManager instance;

    public Button nextRoundButton;


    //(PlantHP, HPlostPerRound, GrowthPerRound, FoodQuality, SunGrowthBoost, SunJarWorth,  BarterPlus, SunJarNeeded, MaxGrowth, Description)
    //public PlantItem Mushroom = new PlantItem(10f, 5f, 10f, 5f, 0f, 10f, 0, 0, 10f, "Mushrooms need no SUNLIGHT to grow, they love the dark so they are quite common to the market.");
    //public PlantItem Kale = new PlantItem(20f, 5f, 5f, 10f, 10f, 20f, 1, 1, 15f, "Kale needs very little SUN to grow, but still requires it to finish blooming.");
    //public PlantItem Fruit = new PlantItem(20f, 10f, 1f, 20f, 10f, 40f, 3, 2, 30f, "Fruit is a rich crop that needs constant SUNLIGHT, which makes it higher in demand of the market.");
    public List<SeedItem> getWorldSeeds(){
        return worldSeeds;
    }

    public List<CropItem> getWorldCrops(){
        return worldCrops;
    }
    private void Awake()
    {
        instance = this; 

        // seed init
        mushroom = new SeedItem(PlantType.mushroom, 1);
        kale = new SeedItem(PlantType.kale, 2);
        apple = new SeedItem(PlantType.fruit, 3);
        potato = new SeedItem(PlantType.potato, 4);
        worldSeeds.Add(mushroom);
        worldSeeds.Add(kale);
        worldSeeds.Add(apple);
        worldSeeds.Add(potato);


        // plant init
        mushroomPlant = new CropItem(PlantType.mushroom, 3, 1);
        kalePlant = new CropItem(PlantType.kale, 5, 2);
        applePlant = new CropItem(PlantType.fruit, 5, 3);
        potatoPlant = new CropItem(PlantType.potato, 8, 4);
        worldCrops.Add(mushroomPlant);
        worldCrops.Add(kalePlant);
        worldCrops.Add(applePlant);
        worldCrops.Add(potatoPlant);
    }

    public void NextRound()
    {
        round++;
        Player.instance.sleep();
        PlantLogistics.instance.NextRound();

        Trader.instance.selling = false;
        Trader.instance.setUpShop(round);
    }

}





