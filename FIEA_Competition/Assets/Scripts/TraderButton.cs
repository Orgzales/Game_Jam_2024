using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraderButton : MonoBehaviour
{
    public PlantType plantType;
    public int num;

    private SeedItem item;
    private CropItem crop;

    // [Header("Selling item")]
    // [Header("Selling item")]

  
    public void buySeed()
    {
        foreach (SeedItem x in GameManager.instance.worldSeeds)
        {
            if (x.name == plantType.ToString())
            {
                item = x;
            }
        }

        Trader.instance.currentButton = this;
        Trader.instance.buySeed(item, num);
    }

    public void sellCrop()
    {
        foreach (CropItem x in GameManager.instance.worldCrops)
        {
            if (x.name == plantType.ToString())
            {
                crop = x;
            }
        }


        Trader.instance.currentButton = this;
        Trader.instance.sellCrop(crop, num);
    }
}
