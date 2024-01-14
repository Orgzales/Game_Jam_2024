using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TraderButton : MonoBehaviour
{
    public PlantType plantType;
    public int num;

    private SeedItem item;
    private CropItem crop;

    public TextMeshProUGUI cost;
    public bool isSeed;

    // [Header("Selling item")]
    // [Header("Selling item")]

    private void Start()
    {
        if (isSeed)
        {
            foreach (SeedItem x in GameManager.instance.worldSeeds)
            {
                if (x.name == plantType.ToString())
                {
                    item = x;
                }
            }

            cost.text = item.getPrice() + " Sun Jars";
        }
        else
        {
            foreach (CropItem x in GameManager.instance.worldCrops)
            {
                if (x.name == plantType.ToString())
                {
                    crop = x;
                }
            }

            cost.text = crop.getPrice() + " Sun Jars";
        }
    }

    public void buySeed()
    {
       
        Trader.instance.currentButton = this;
        Trader.instance.buySeed(item, num);
    }

    public void sellCrop()
    {
        
        Trader.instance.currentButton = this;
        Trader.instance.sellCrop(crop, num);
    }
}
