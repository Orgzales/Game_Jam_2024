using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
    public GameObject DayButton; //make same as nextround button
    public TextMeshProUGUI DayCounter;

    bool FadeScreen = false;
    public Image BlackScreen;
    public AudioSource FadeSound;
    public AudioSource SleepSound;
    float BlackColor = 0;

    //(PlantHP, HPlostPerRound, GrowthPerRound, FoodQuality, SunGrowthBoost, SunJarWorth,  BarterPlus, SunJarNeeded, MaxGrowth, Description)
    //public PlantItem Mushroom = new PlantItem(10f, 5f, 10f, 5f, 0f, 10f, 0, 0, 10f, "Mushrooms need no SUNLIGHT to grow, they love the dark so they are quite common to the market.");
    //public PlantItem Kale = new PlantItem(20f, 5f, 5f, 10f, 10f, 20f, 1, 1, 15f, "Kale needs very little SUN to grow, but still requires it to finish blooming.");
    //public PlantItem Fruit = new PlantItem(20f, 10f, 1f, 20f, 10f, 40f, 3, 2, 30f, "Fruit is a rich crop that needs constant SUNLIGHT, which makes it higher in demand of the market.");
    public List<SeedItem> getWorldSeeds()
    {
        return worldSeeds;
    }

    public List<CropItem> getWorldCrops()
    {
        return worldCrops;
    }
    private void Awake()
    {
        // BlackScreen.SetActive(false);
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
        mushroomPlant = new CropItem(PlantType.mushroom, 8, 2);
        kalePlant = new CropItem(PlantType.kale, 15, 4);
        applePlant = new CropItem(PlantType.fruit, 15, 8);
        potatoPlant = new CropItem(PlantType.potato, 30, 10);
        worldCrops.Add(mushroomPlant);
        worldCrops.Add(kalePlant);
        worldCrops.Add(applePlant);
        worldCrops.Add(potatoPlant);
    }

    void Update()
    {
        if (FadeScreen)
        {
            if (BlackColor < 250f)
            {
                BlackColor = BlackColor + 0.01f;
            }

            BlackScreen.color = new Color(0.0f, 0.0f, 0.0f, BlackColor);
        }
        if (!FadeScreen)
        {
            if (BlackColor > 0.0f)
            {
                BlackColor = BlackColor - 0.01f;
            }

            BlackScreen.color = new Color(0.0f, 0.0f, 0.0f, BlackColor);
        }
    }

    public void NextRound()
    {
        round++;
        SleepSound.Play();
        FadeScreen = true;
        StartCoroutine("NextRoundButtonWait");
        DayCounter.text = round.ToString();
        DayButton.SetActive(false);

        // Player.instance.sleep();

        // foreach (GardenTile x in GardenManager.instance.tiles) //this is how u will call into plant logistics
        // {
        //     if (x.plant)
        //     {
        //         x.plant.GetComponent<PlantLogistics>().NextRound();
        //     }
        // }

        // Trader.instance.selling = false;
        // Trader.instance.setUpShop(round);

    }

    IEnumerator NextRoundButtonWait()
    {
        yield return new WaitForSeconds(2);
        SleepSound.Stop();
        FadeSound.Play();
        DayButton.SetActive(true);
        FadeScreen = false;

        Player.instance.sleep();

        foreach (GardenTile x in GardenManager.instance.tiles) //this is how u will call into plant logistics
        {
            if (x.plant)
            {
                x.plant.GetComponent<PlantLogistics>().NextRound();
            }
        }

        Trader.instance.selling = false;
        Trader.instance.setUpShop(round);


        foreach (GardenTile x in GardenManager.instance.tiles)
        {
            if (x.plant)
            {
                x.plant.GetComponent<PlantLogistics>().GotSun = false;

            }
            x.clearMenu();
        }
    }

}





